import ticketBookingApiInstance from './http-interceptor'

export class ConcertService {
    ticketBookingApi = ticketBookingApiInstance;

    getConcertList(concertName, concertType) {
        var urlAdd = ''
        if (concertName && concertName.length > 0) urlAdd += '?containsInName=' + concertName //
        if (concertType && concertType.length > 0) {
            if (urlAdd.length === 0) {
                urlAdd += '?concertType=' + concertType
            }
            else {
                urlAdd += '&concertType=' + concertType
            }
        }
        return this.ticketBookingApi.get('/api/concerts' + urlAdd)
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
