namespace TicketBooking.Domain
{
    public class Party : Concert
    {
        public Party() { ConcertType = nameof(Party); }
        public int AgeLimit { get; set; }
    }
}
