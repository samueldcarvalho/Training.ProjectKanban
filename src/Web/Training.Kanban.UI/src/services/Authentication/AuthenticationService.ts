/** @format */

import { execFileSync } from "child_process";
import { randomUUID } from "crypto";
import { AuthAPI } from "../AuthApi";
import { TokenService } from "./TokenService";

const Login = async (LoginData: { username: string; password: string }) => {
  // await AuthAPI.post("", LoginData);
  if (LoginData.password == "12345" && LoginData.username == "samuel") {
    TokenService.Save("1234567");
    return true;
  } else return false;
};

export const AuthenticationService = {
  Login,
};
