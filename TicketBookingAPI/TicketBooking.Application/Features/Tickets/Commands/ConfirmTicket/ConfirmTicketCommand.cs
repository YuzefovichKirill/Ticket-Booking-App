using MediatR;

namespace TicketBooking.Application.Features.Tickets.Commands.ConfirmTicket
{
    public class ConfirmTicketCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
