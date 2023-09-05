using MediatR;

namespace TicketBooking.Application.Features.Tickets.Commands.ApprovePaymentTicket
{
    public class ApprovePaidTicketCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
