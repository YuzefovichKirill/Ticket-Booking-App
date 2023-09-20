import ticketBookingAPIInstance from "./http-interceptor";

export class OrderService {
  ticketBookingApi = ticketBookingAPIInstance;

  createPreOrder(body)
  {
    return this.ticketBookingApi.post('/api/orders/pre-order', body)
  }

  createOrder(body)
  {
    return this.ticketBookingApi.post('/api/orders', body)
  }

  deletePreOrder(body)
  {
    return this.ticketBookingApi.put('/api/orders/pre-order', body)
  }
}