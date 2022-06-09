import Router from "next/router";
import { setCookie } from "nookies";
import { createContext, ReactNode, useState } from "react";
import { User } from "../../models/User";
import { AuthenticationService } from "../../services/Authentication/AuthenticationService";

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
  const isAuthenticated = !!user;

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
