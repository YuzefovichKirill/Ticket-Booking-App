using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicketList
{
    public class GetTicketListQueryHandler : IRequestHandler<GetTicketListQuery, TicketListVm>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public GetTicketListQueryHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<TicketListVm> Handle(GetTicketListQuery request, CancellationToken cancellationToken)
        {
            var ticketsList = await _ticketBookingDbContext.Tickets.Where(t => t.UserId == request.UserId).ToListAsync();
            var ConcertIds = ticketsList.Select(t => t.ConcertId).ToList();
            var concertsList = await _ticketBookingDbContext.Concerts.Where(c => ConcertIds.Contains(c.Id)).ToListAsync();

            List<TicketVm> ticketVms = ticketsList.Join(concertsList, t => t.ConcertId, c => c.Id, (t, c) => new TicketVm()
            {
                Id = t.Id,
                ConcertId = t.ConcertId,
                ConcertName = c.ConcertName,
                ConcertTime = c.DateTime
            }).ToList();

            return new TicketListVm() { Tickets = ticketVms };
        }
    }
}
