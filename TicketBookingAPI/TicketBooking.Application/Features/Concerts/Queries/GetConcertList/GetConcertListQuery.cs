using MediatR;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcertList
{
    public class GetConcertListQuery : IRequest<ConcertListVm> 
    {
        public string? ContainsInName { get; set; }
        public string? ConcertType { get; set; }
    }
}
