using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Persistance.Configuration;

namespace TicketBooking.Persistance
{
    public class TicketBookingDbContext : DbContext, ITicketBookingDbContext
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ClassicalConcert> ClassicalConcerts { get; set; }
        public DbSet<OpenAir> OpenAirs { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public TicketBookingDbContext(DbContextOptions<TicketBookingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Concert>().UseTptMappingStrategy();

            builder.ApplyConfiguration(new ConcertConfiguration());
            builder.ApplyConfiguration(new ClassicalConcertConfiguration());
            builder.ApplyConfiguration(new OpenAirConfiguration());
            builder.ApplyConfiguration(new PartyConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
