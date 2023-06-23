namespace TicketBooking.Domain
{
    public class Concert 
    {
        public Guid Id { get; set; }
        public string? ConcertName { get; set; }
        public string? BandName { get; set; }
        public int AmountOfTickets { get; set; }
        public int AmountOfAvailableTickets { get; set; }
        public DateTime DateTime { get; set; }
        public string? Place { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
        public string? ConcertType { get; set; } = "Concert";
    }
}
