namespace TicketBooking.Domain
{
    public class Party : Concert
    {
        public Party() : base(ConcertType.Party) { }
        public int AgeLimit { get; set; }
    }
}
