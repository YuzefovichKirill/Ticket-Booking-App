import ticketBookingAPIInstance from "./http-interceptor";
  
export class CouponService {
  ticketBookingApi = ticketBookingAPIInstance;

  getCouponList() {
    return this.ticketBookingApi.get('api/coupons')
  }

  createCoupon(body) {
    return this.ticketBookingApi.post('/api/coupons', body)
  }

  deleteCoupon(id) {
    return this.ticketBookingApi.delete(`/api/coupons/${id}`)
  }
}


