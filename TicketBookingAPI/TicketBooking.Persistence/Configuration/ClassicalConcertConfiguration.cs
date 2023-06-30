using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain;

namespace TicketBooking.Persistence.Configuration
{
    public class ClassicalConcertConfiguration : IEntityTypeConfiguration<ClassicalConcert>
    {
        public void Configure(EntityTypeBuilder<ClassicalConcert> builder)
        {
            builder.Property(c => c.VoiceType).HasMaxLength(20);
            builder.Property(c => c.Composer).HasMaxLength(20);
        }
    }
}
