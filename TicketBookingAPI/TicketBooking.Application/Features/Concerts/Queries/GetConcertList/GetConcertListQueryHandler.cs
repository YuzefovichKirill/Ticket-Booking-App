using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcertList
{
    public class GetConcertListQueryHandler : IRequestHandler<GetConcertListQuery, ConcertListVm>
    {
        private readonly IConcertRepository _concertRepository;

        public GetConcertListQueryHandler(
            IConcertRepository concertRepository)
        {
            _concertRepository = concertRepository;
        }

        public async Task<ConcertListVm> Handle(GetConcertListQuery request,
            CancellationToken cancellationToken)
        {
            List<Concert> concerts = await _concertRepository.GetListWithFiltersAsync(request.ContainsInName,
                request.ConcertType, cancellationToken);

            var ConcertListDtos = concerts.Select(c => new ConcertDto()
            {
                Id = c.Id,
                ConcertName = c.ConcertName,
                BandName = c.BandName,
                AmountOfAvailableTickets = c.AmountOfAvailableTickets,
                ConcertType = c.ConcertType,
                DateTime = c.DateTime,
                Place = c.Place,
                GeoLat = c.GeoLat,
                GeoLng = c.GeoLng,
                Price = c.Price
            }).ToList();

            return new ConcertListVm() { Concerts = ConcertListDtos };
        }
    }
}
