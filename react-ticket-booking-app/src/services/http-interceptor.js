import axios from "axios";
import environment from "../environments/environment";
import { getAccessToken } from "./auth-service";

const ticketBookingAPIInstance = axios.create({
    baseURL: environment.TicketBookingAPIUrl
});
ticketBookingAPIInstance.interceptors.request.use(async (config) => {
    var token = await getAccessToken()
    if (token) {
        config.headers.Authorization = `Bearer ${token}`
    }
    return config;
})

export default ticketBookingAPIInstance
