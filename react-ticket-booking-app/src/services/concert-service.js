import ticketBookingApiInstance from './http-interceptor'

export class ConcertService {
    ticketBookingApi = ticketBookingApiInstance;

    getConcertList() {
        return this.ticketBookingApi.get('/api/concerts')
    }

    getConcert(id) {
        return this.ticketBookingApi.get(`/api/concerts/${id}`)
    }

    createConcert(body) {
        return this.ticketBookingApi.post(`/api/concerts`, body)
    }

    deleteConcert(id) {
        return this.ticketBookingApi.delete(`/api/concerts/${id}`)
    }
}
