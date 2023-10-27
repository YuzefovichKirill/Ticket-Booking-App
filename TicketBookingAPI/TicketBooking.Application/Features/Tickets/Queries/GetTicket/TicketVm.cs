namespace TicketBooking.Application.Features.Tickets.Queries.GetTicket
{
    public class TicketVm
    {
        public Guid ConcertId { get; set; }
        public string? ConcertName { get; set; }
        public DateTime ConcertTime { get; set; }
        public int AmountOfTickets { get; set; }
    }
}
