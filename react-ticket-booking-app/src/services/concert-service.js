import ticketBookingApiInstance from './http-interceptor'

export class ConcertService {
    ticketBookingApi = ticketBookingApiInstance;

    getConcertList() {
        return this.ticketBookingApi.get('/api/concerts')
    }

    getConcert(id) {
        return this.ticketBookingApi.get(`/api/concerts/${id}`)
    }
}
