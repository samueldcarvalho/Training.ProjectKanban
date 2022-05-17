import axios from "axios";

export const AuthAPI = axios.create({
    baseURL: "https://localhost:44309/api/Authentication",
    responseType: "json"
})
