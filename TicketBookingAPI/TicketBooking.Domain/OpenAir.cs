namespace TicketBooking.Domain
{
    public class OpenAir : Concert
    {
        public OpenAir() : base(nameof(OpenAir)) { }
        public string? GettingHere { get; set; }
        public string? HeadLiner { get; set; }
    }
}
