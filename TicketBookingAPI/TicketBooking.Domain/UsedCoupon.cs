namespace TicketBooking.Domain
{
    public class UsedCoupon
    {
        public int Id { get; set; }
        public Guid CouponId { get; set; }
        public Guid UserId { get; set; }
    }
}
