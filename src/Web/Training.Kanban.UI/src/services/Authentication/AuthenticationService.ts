/** @format */

import { API } from "../Api";
import { TokenService } from "./TokenService";

const Login = async (LoginData: { username: string; password: string }) => {
  // await AuthAPI.post("", LoginData);

  const response = await API.post("authentication/authenticate", LoginData, {
    headers: {
      "Content-Type": "application/json",
    },
    responseType: "json",
  });

  console.log(response.data.token);
  TokenService.Save(response.data.token);
};

export const AuthenticationService = {
  Login,
};
