using MediatR;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcert
{
    public class GetConcertQuery : IRequest<Concert>
    {
        public Guid Id { get; set; }
    }
}
