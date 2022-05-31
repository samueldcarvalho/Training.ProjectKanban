/** @format */

import { AuthAPI } from "../AuthApi";

class AuthenticationService {
  async Login(LoginData: { username: string; password: string }) {
    await AuthAPI.post("", LoginData);
  }
}

export default AuthenticationService;
