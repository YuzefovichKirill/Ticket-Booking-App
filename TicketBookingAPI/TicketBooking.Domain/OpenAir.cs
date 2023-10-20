namespace TicketBooking.Domain
{
    public class OpenAir : Concert
    {
        public OpenAir() : base(ConcertType.OpenAir) { }
        public string? GettingHere { get; set; }
        public string? Headliner { get; set; }
    }
}
