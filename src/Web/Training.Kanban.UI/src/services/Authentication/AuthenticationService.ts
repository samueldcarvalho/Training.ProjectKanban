/** @format */

import { LoginDataType } from "../../contexts/Authentication/AuthContext";
import { UserAuthenticationViewModel } from "../../models/ViewModels/UserAuthentication";
import { API } from "../Api";

const Login = async (LoginData: LoginDataType) => {
  const response = await API.post("authentication/authenticate", LoginData, {
    headers: {
      "Content-Type": "application/json",
    },
    responseType: "json",
  });

  return response.data as UserAuthenticationViewModel;
};

export const AuthenticationService = {
  Login,
};
