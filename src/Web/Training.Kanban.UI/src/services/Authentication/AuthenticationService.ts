/** @format */

import { LoginDataType } from "../../contexts/Authentication/AuthContext";
import { User } from "../../models/User";
import { UserAuthenticationViewModel } from "../../models/ViewModels/UserAuthentication";
import { API } from "../Api";

const Login = async (LoginData: LoginDataType) => {
  const response = await API.post("/authentication/auth", LoginData, {
    data: LoginData,
    headers: {
      "Content-Type": "application/json",
    },
    responseType: "json",
  });

  return response.data as UserAuthenticationViewModel;
};

const GetUserById = async (id: number) => {
  const response = await API.get("/authentication/auth/" + id, {
    responseType: "json",
  });
  return response.data as User;
};

export const AuthenticationService = {
  Login,
  GetUserById,
};
