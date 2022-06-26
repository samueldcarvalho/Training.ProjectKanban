import Router from "next/router";
import { destroyCookie, parseCookies, setCookie } from "nookies";
import { createContext, ReactNode, useContext, useEffect, useState } from "react";
import { User } from "../../models/User";
import { AuthenticationService } from "../../services/Authentication/AuthenticationService";
import * as jwtDecode from "jwt-decode";
import { LoadingContext } from "../Loading/LoadingContext";
import { ToastContext, ToastType } from "../Toast/ToastContext";
import { AxiosError } from "axios";

export type LoginDataType = {
  username: string;
  password: string;
};

type AuthContextType = {
  isAuthenticated: boolean;
  user: User | null;
  Authenticate: (loginData: LoginDataType) => Promise<void>;
  Logout: () => Promise<void>;
};

export const AuthContext = createContext({} as AuthContextType);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const { useToast } = useContext(ToastContext);
  const { LoadingHandler } = useContext(LoadingContext);
  const isAuthenticated = !!user;

  useEffect(() => {
    LoadingHandler({
      isLoading: true,
      loadingText: "Getting user data",
    });
    const { "kanban.token": token } = parseCookies();

    try {
      if (token) {
        AuthenticationService.GetUserById((jwtDecode.default(token) as any).Id)
          .then((u) => {
            setUser(u);
          })
          .catch((er) => useToast({ type: ToastType.Danger, title: "Error", message: er.text }));
      }
    } finally {
      LoadingHandler({
        isLoading: false,
        loadingText: "",
      });
    }
  }, []);

  async function Authenticate({ username, password }: LoginDataType) {
    LoadingHandler({
      isLoading: true,
      loadingText: "Authenticating",
    });

    await delay(1000);

    try {
      try {
        const { token, user } = await AuthenticationService.Login({
          username,
          password,
        });

        if (!token || !user) return;

        setCookie(undefined, "kanban.token", token, {
          maxAge: 60 * 60 * 1, // 1 hora
        });

        setUser(user);
        Router.push("/");
      } catch (err) {
        const er = err as AxiosError;

        let message = "";

        if (er.response?.status == 401) message = "Invalid password or username";
        else message = er.message;

        useToast({
          type: ToastType.Danger,
          title: "Error",
          message: message,
        });
      }
    } finally {
      LoadingHandler({
        isLoading: false,
        loadingText: "",
      });
    }
  }

  async function Logout() {
    LoadingHandler({
      isLoading: true,
      loadingText: "Logging out",
    });

    await delay(1000);

    try {
      destroyCookie(undefined, "kanban.token");
      setUser(null);
      Router.push("/login");
    } finally {
      LoadingHandler({
        isLoading: false,
        loadingText: "",
      });
    }
  }

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        user,
        Authenticate,
        Logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

const delay = (amount: number = 750) => new Promise((resolve) => setTimeout(resolve, amount));
