using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Domain;

namespace TicketBooking.Persistence.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
        }
    }
}
