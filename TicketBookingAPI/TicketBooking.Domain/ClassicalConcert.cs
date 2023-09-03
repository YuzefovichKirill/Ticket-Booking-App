namespace TicketBooking.Domain
{
    public class ClassicalConcert : Concert
    {
        public ClassicalConcert() : base(nameof(ClassicalConcert)) { }
        public string? VoiceType { get; set; }
        public string? Composer { get; set; }
    }
}
