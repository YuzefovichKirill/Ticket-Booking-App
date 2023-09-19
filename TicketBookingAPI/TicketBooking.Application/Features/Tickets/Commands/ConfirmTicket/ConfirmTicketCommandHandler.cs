using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Commands.ConfirmTicket
{
    public class ConfirmTicketCommandHandler: IRequestHandler<ConfirmTicketCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public ConfirmTicketCommandHandler(ITicketBookingDbContext ticketBookingDbContext)
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(ConfirmTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketBookingDbContext.Tickets.FindAsync(new object[] { request.Id });

            if (ticket is null) 
            {
                throw new NotFoundException("There is no such ticket");
            }

            //ticket.IsConfirmed = true;
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
