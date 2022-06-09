import Router from "next/router";
import { parseCookies, setCookie } from "nookies";
import { createContext, ReactNode, useContext, useEffect, useState } from "react";
import { User } from "../../models/User";
import { AuthenticationService } from "../../services/Authentication/AuthenticationService";
import * as jwtDecode from "jwt-decode";
import LoadingModal from "../../components/globals/Loading/Modal/LoadingModal";
import { LoadingContext } from "../Loading/LoadingContext";

export type LoginDataType = {
  username: string;
  password: string;
};

type AuthContextType = {
  isAuthenticated: boolean;
  user: User | null;
  Authenticate: (loginData: LoginDataType) => Promise<void>;
};

export const AuthContext = createContext({} as AuthContextType);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const { isLoading } = useContext(LoadingContext);
  const isAuthenticated = !!user;
  console.log(isAuthenticated);

  useEffect(() => {
    const { "kanban.token": token } = parseCookies();

    if (token) {
      AuthenticationService.GetUserById((jwtDecode.default(token) as any).Id)
        .then((u) => {
          setUser(u);
          Router.push("/");
        })
        .catch(() => Router.push("/login"));
    }
  }, []);

  async function Authenticate({ username, password }: LoginDataType) {
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
  }

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        user,
        Authenticate,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
