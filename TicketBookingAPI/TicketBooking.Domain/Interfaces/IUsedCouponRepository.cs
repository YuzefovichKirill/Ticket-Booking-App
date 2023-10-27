namespace TicketBooking.Domain.Interfaces
{
    public interface IUsedCouponRepository
    {
        public Task AddAsync(UsedCoupon usedCoupon, CancellationToken cancellation);
        public void DeleteRange(IEnumerable<UsedCoupon> usedCoupons);
        public Task<UsedCoupon> GetByCouponIdAsync(Guid userId, Guid CouponId, CancellationToken cancellationToken);
    }
}
