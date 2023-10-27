using Microsoft.EntityFrameworkCore;
using TicketBooking.Domain;

namespace TicketBooking.Application.Interfaces
{
    public interface ITicketBookingDbContext
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ClassicalConcert> ClassicalConcerts { get; set; }
        public DbSet<OpenAir> OpenAirs { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<UsedCoupon> UsedCoupons { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
