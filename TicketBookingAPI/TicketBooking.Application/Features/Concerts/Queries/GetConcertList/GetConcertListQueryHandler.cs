using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcertList
{
    public class GetConcertListQueryHandler : IRequestHandler<GetConcertListQuery, ConcertListVm>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public GetConcertListQueryHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<ConcertListVm> Handle(GetConcertListQuery request,
            CancellationToken cancellationToken)
        {
            List<Concert> concerts;

            if (!String.IsNullOrEmpty(request.ContainsInName) && !String.IsNullOrEmpty(request.ConcertType))
            {
                concerts = await _ticketBookingDbContext.Concerts
                    .Where(c => c.ConcertName.Contains(request.ContainsInName) &&  c.ConcertType == request.ConcertType)
                    .ToListAsync(cancellationToken);
            }
            else if (!String.IsNullOrEmpty(request.ContainsInName))
            {
                concerts = await _ticketBookingDbContext.Concerts
                    .Where(c => c.ConcertName.Contains(request.ContainsInName))
                    .ToListAsync(cancellationToken);
            }
            else if (!String.IsNullOrEmpty(request.ConcertType))
            {
                concerts = await _ticketBookingDbContext.Concerts
                    .Where(c => c.ConcertType == request.ConcertType)
                    .ToListAsync(cancellationToken);
            }
            else
            {
                concerts = await _ticketBookingDbContext.Concerts.ToListAsync(cancellationToken);
            }

            var ConcertListDtos = concerts.Select(c => new ConcertDto()
            {
                Id = c.Id,
                ConcertName = c.ConcertName,
                BandName = c.BandName,
                AmountOfAvailableTickets = c.AmountOfAvailableTickets,
                ConcertType = c.ConcertType,
                DateTime = c.DateTime,
                Place = c.Place
            }).ToList();

            return new ConcertListVm() { Concerts = ConcertListDtos };
        }
    }
}
