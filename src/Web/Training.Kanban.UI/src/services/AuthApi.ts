import axios from "axios";

export const AuthAPI = axios.create({
    baseURL: process.env.AUTHENTICATION_URL,
    responseType: "json"
})
