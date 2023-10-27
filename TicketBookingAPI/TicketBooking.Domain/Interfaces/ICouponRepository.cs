namespace TicketBooking.Domain.Interfaces
{
    public interface ICouponRepository
    {
        public Task AddAsync(Coupon coupon, CancellationToken cancellationToken);
        public void Delete(Coupon coupon);
        public Task<Coupon> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<Coupon> GetByNameAsync(string name, CancellationToken cancellationToken);
        public Task<List<Coupon>> GetListAsync(CancellationToken cancellationToken);
    }
}
