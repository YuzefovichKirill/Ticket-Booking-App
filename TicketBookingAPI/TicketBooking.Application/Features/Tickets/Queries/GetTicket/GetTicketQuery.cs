using MediatR;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicket
{
    public class GetTicketQuery : IRequest<TicketVm>
    {
        public Guid UserId { get; set; }
        public Guid ConcertId { get; set; }
    }
}
