import axios from "axios";
import { parseCookies } from "nookies";

const { "kanban.token": token } = parseCookies();

export const API = axios.create({
  baseURL: "https://localhost:5001/api",
  responseType: "json",
  headers: {
    Authorization: token ? `Bearer ${token}` : "",
  },
});
