using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicket
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, TicketVm>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public GetTicketQueryHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<TicketVm> Handle(GetTicketQuery request, 
            CancellationToken cancellationToken)
        {
            var tickets = await _ticketBookingDbContext.Tickets
                .Where(t => t.UserId == request.UserId && t.ConcertId == request.ConcertId)
                .ToListAsync();

            if (!tickets.Any())
            {
                throw new Exception("There is no tickets in db with this ids");
            }

            var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { request.ConcertId });

            if (concert is null)
            {
                throw new Exception("There is no concert in db with this id");
            }

            string concertName = concert.ConcertName;
            DateTime concertTime = concert.DateTime;

            TicketVm ticketVm = new TicketVm()
            {
                ConcertId = request.ConcertId,
                ConcertName = concertName,
                ConcertTime = concertTime,
                AmountOfTickets = tickets.Count
            };
            return ticketVm;
        }
    }
}
