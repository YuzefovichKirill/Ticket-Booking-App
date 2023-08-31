using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public CreateTicketCommandHandler(ITicketBookingDbContext ticketBookingDbContext) 
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<Guid> Handle(CreateTicketCommand request, 
            CancellationToken cancellationToken)
        {
            Ticket ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                ConcertId = request.ConcertId,
                IsConfirmed = false
            };

            await _ticketBookingDbContext.Tickets.AddAsync(ticket, cancellationToken);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
            return ticket.Id;
        }
    }
}
