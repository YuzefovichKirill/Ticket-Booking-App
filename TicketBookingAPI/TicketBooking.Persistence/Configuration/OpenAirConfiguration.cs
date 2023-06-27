using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBooking.Domain;

namespace TicketBooking.Persistance.Configuration
{
    public class OpenAirConfiguration : IEntityTypeConfiguration<OpenAir>
    {
        public void Configure(EntityTypeBuilder<OpenAir> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasIndex(o => o.Id).IsUnique();
        builder.Property(o => o.GettingHere).HasMaxLength(100);
        builder.Property(o => o.HeadLiner).HasMaxLength(20);
    }
}
}
