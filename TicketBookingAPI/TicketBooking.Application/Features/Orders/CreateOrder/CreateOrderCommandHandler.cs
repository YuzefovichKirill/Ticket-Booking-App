using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public CreateOrderCommandHandler(ITicketBookingDbContext ticketBookingDbContext)
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            foreach (var ticketDto in request.Tickets)
            {
                var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { ticketDto.ConcertId });

                if (concert is null)
                {
                    throw new NotFoundException($"There is no such concert (Concert name: {ticketDto.ConcertName})");
                }

                for (int i =  0; i < ticketDto.Quantity; i++)
                {
                    await _ticketBookingDbContext.Tickets.AddAsync(new Ticket() 
                    { 
                        Id = Guid.NewGuid(),
                        UserId = request.UserId,
                        ConcertId = ticketDto.ConcertId,
                    }, cancellationToken);
                }
            }

            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
