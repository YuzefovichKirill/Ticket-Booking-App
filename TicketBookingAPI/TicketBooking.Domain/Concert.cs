namespace TicketBooking.Domain
{
    public abstract class Concert 
    {
        public Guid Id { get; set; }
        public string? ConcertName { get; set; }
        public string? BandName { get; set; }
        public int AmountOfTickets { get; set; }
        public int AmountOfAvailableTickets { get; set; }
        public DateTime DateTime { get; set; }
        public string? Place { get; set; }
        public double GeoLng { get; set; }
        public double GeoLat { get; set; }
        public string? ConcertType { get; } = nameof(Concert);
        public List<Ticket> Tickets { get; set; } = new();
   
        public Concert(string concertType) => ConcertType = concertType;    
    }
}
