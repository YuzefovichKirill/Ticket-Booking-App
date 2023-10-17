using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Persistence.Repositories
{
    internal sealed class UsedCouponRepository : IUsedCouponRepository
    {
        private readonly ITicketBookingDbContext _context;

        public UsedCouponRepository(ITicketBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UsedCoupon usedCoupon, CancellationToken cancellationToken)
        {
            await _context.UsedCoupons.AddAsync(usedCoupon, cancellationToken);
        }

        public void DeleteRange(IEnumerable<UsedCoupon> usedCoupons)
        {
            _context.UsedCoupons.RemoveRange(usedCoupons);
        }

        public async Task<UsedCoupon> GetByCouponIdAsync(Guid userId, Guid couponId, CancellationToken cancellationToken)
        {
            return await _context.UsedCoupons.FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CouponId == couponId, cancellationToken);
        }
    }
}
