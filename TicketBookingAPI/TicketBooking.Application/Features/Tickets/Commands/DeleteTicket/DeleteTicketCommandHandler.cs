using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Commands.DeleteTicket
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public DeleteTicketCommandHandler(ITicketBookingDbContext ticketBookingDbContext)
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(DeleteTicketCommand request,
            CancellationToken cancellationToken)
        {
            var ticket = await _ticketBookingDbContext.Tickets.FindAsync(new object[] { request.Id }, cancellationToken);
            
            if (ticket is null)
            {
                throw new NotFoundException("There is no such ticket");
            }

            _ticketBookingDbContext.Tickets.Remove(ticket);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
