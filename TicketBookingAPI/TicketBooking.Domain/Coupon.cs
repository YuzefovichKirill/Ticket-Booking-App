namespace TicketBooking.Domain
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public Guid ConcertId { get; set; }
        public string? Name { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
