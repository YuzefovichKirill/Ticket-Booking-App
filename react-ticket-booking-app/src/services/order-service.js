import ticketBookingAPIInstance from "./http-interceptor";

export class OrderService {
  ticketBookingApi = ticketBookingAPIInstance;

  createOrder(body)
  {
    return this.ticketBookingApi.post('/api/orders', body)
  }
}