namespace TicketBooking.Domain
{
    public class Party : Concert
    {
        public Party() : base(nameof(Party)) { }
        public int AgeLimit { get; set; }
    }
}
