using MediatR;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateOpenAir
{
    public class CreateOpenAirCommand : IRequest<Guid>
    {
        public string? ConcertName { get; set; }
        public string? BandName { get; set; }
        public int AmountOfTickets { get; set; }
        public int AmountOfAvailableTickets { get; set; }
        public DateTime DateTime { get; set; }
        public string? Place { get; set; }
        public double GeoLng { get; set; }
        public double GeoLat { get; set; }
        public string? ConcertType { get; set; }
        public int Price { get; set; }

        public string? GettingHere { get; set; }
        public string? Headliner { get; set; }
    }
}
