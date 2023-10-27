using MediatR;

namespace TicketBooking.Application.Features.Tickets.Commands.ApprovePaidTicket
{
    public class ApprovePaidTicketCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
