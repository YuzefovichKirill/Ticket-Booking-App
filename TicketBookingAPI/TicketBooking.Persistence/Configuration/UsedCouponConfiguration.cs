using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBooking.Domain;

namespace TicketBooking.Persistence.Configuration
{
    public class UsedCouponConfiguration : IEntityTypeConfiguration<UsedCoupon>
    {
        public void Configure(EntityTypeBuilder<UsedCoupon> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Id).IsUnique();
            builder.HasIndex(u => new { u.UserId, u.CouponId });
        }
    }
}
