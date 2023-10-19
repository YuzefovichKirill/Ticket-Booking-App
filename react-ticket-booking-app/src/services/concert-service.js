import ticketBookingApiInstance from './http-interceptor'

export class ConcertService {
    ticketBookingApi = ticketBookingApiInstance;

    getConcertList(containsInName, concertType) {
        const searchParams = new URLSearchParams()
        if (containsInName !== null && containsInName !== '') searchParams.set('containsInName', containsInName)
        if (concertType !== null && concertType !== '')  searchParams.set('concertType', concertType)
        return this.ticketBookingApi.get('/api/concerts?' + searchParams.toString())
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
