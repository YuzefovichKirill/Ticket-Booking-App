using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Persistence.Repositories
{
    internal sealed class CouponRepository: ICouponRepository
    {
        private readonly ITicketBookingDbContext _context;

        public CouponRepository(ITicketBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Coupon coupon, CancellationToken cancellationToken)
        {
            await _context.Coupons.AddAsync(coupon, cancellationToken);
        }

        public void Delete(Coupon coupon)
        {
            _context.Coupons.Remove(coupon);
        }

        public async Task<Coupon> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
           return await _context.Coupons.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Coupon> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
        }

        public async Task<List<Coupon>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _context.Coupons.ToListAsync(cancellationToken);
        }
    }
}
