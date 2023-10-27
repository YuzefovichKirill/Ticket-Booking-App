using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcertList
{
    public class ConcertDto
    {
        public Guid Id { get; set; }
        public string? ConcertName { get; set; }
        public string? BandName { get; set; }
        public int AmountOfAvailableTickets { get; set; }
        public DateTime DateTime { get; set; }
        public string? Place { get; set; }
        public double GeoLng { get; set; }
        public double GeoLat { get; set; }
        public ConcertType ConcertType { get; set; }
        public int Price { get; set; }

    }
}
