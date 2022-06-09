import { createContext, ReactNode } from "react";
import { AuthenticationService } from "../../services/Authentication/AuthenticationService";

type AuthContextType = {
  isAuthenticated: boolean;
  Authenticate: (loginData: LoginDataType) => void;
};

export type LoginDataType = {
  username: string;
  password: string;
};

export const AuthContext = createContext({} as AuthContextType);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const isAuthenticated = false;

  async function Authenticate({ username, password }: LoginDataType) {
    const { token, user } = await AuthenticationService.Login({
      username,
      password,
    });
  }

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        Authenticate,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
