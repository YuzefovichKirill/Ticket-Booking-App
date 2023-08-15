using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBooking.Domain;

namespace TicketBooking.Persistence.Configuration
{
    public class OpenAirConfiguration : IEntityTypeConfiguration<OpenAir>
    {
        public void Configure(EntityTypeBuilder<OpenAir> builder)
        {
            builder.Property(o => o.GettingHere).HasMaxLength(100);
            builder.Property(o => o.Headliner).HasMaxLength(20);
        }
    }
}
