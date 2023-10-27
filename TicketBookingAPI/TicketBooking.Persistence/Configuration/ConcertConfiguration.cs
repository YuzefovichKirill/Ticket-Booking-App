using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketBooking.Domain;

namespace TicketBooking.Persistence.Configuration
{
    public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id).IsUnique();
            builder.Property(c => c.ConcertName).HasMaxLength(20);
            builder.Property(c => c.BandName).HasMaxLength(20);
            builder.Property(c => c.Place).HasMaxLength(100);
        }
    }
}
