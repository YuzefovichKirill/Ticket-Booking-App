using MediatR;

namespace TicketBooking.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ConcertId { get; set; }
    }
}
