using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Commands.ApprovePaymentTicket
{
    public class ApprovePaidTicketCommandHandler: IRequestHandler<ApprovePaidTicketCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public ApprovePaidTicketCommandHandler(ITicketBookingDbContext ticketBookingDbContext)
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(ApprovePaidTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketBookingDbContext.Tickets.FindAsync(new object[] { request.Id });

            if (ticket is null)
            {
                throw new NotFoundException("There is no such ticket");
            }

            ticket.IsPaid = true;
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
