import axios from "axios";

export const Api = axios.create({
    baseURL: "https://regres.in/api/"
})