import ticketBookingApiInstance from './http-interceptor'

export class TicketService {
    ticketBookingApi = ticketBookingApiInstance;

    getTicketList() {
        return this.ticketBookingApi.get('/api/tickets')
    }

    getTicket(id) {
        return this.ticketBookingApi.get(`/api/tickets/${id}`)
    }

    createTicket(id) {
        return this.ticketBookingApi.post(`/api/tickets`, id)
                                                        //JSON.stringify(body)
                                                        //{ concertId: id }
    }

    deleteTicket(id) {
        return this.ticketBookingApi.delete(`/api/tickets/${id}`)
    }
}
