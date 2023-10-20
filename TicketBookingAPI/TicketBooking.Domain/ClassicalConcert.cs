namespace TicketBooking.Domain
{
    public class ClassicalConcert : Concert
    {
        public ClassicalConcert() : base(ConcertType.ClassicalConcert) { }
        public string? VoiceType { get; set; }
        public string? Composer { get; set; }
    }
}
