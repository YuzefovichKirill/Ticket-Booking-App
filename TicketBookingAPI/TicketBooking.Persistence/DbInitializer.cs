using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain;

namespace TicketBooking.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TicketBookingDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Guid[] concertGuids = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            Guid[] ticketGuids = { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            context.Concerts.AddRange(new List<Concert>
            {
                new ClassicalConcert()
                {
                    Id = concertGuids[0],
                    ConcertName = "Classical concert 1",
                    BandName = "Classical band",
                    AmountOfTickets = 150,
                    AmountOfAvailableTickets = 145,
                    DateTime = DateTime.Now,
                    Place = "Vitebsk",
                    GeoLng = 55.1904,
                    GeoLat = 30.2049,

                    Composer = "Very famous composer", 
                    VoiceType = "Tenor"
                },
                new OpenAir()
                {
                    Id = concertGuids[1],
                    ConcertName = "Open air concert 1",
                    BandName = "Open air band",
                    AmountOfTickets = 500,
                    AmountOfAvailableTickets = 500,
                    DateTime = DateTime.Now,
                    Place = "Minsk",
                    GeoLng = 53.9,
                    GeoLat = 27.5667,

                    GettingHere = "Some guide",
                    Headliner = "Some band"
                },
                new Party() 
                {
                    Id = concertGuids[2],
                    ConcertName = "Party concert 1",
                    BandName = "Party band",
                    AmountOfTickets = 30,
                    AmountOfAvailableTickets = 0,
                    DateTime = DateTime.Now,
                    Place = "Minsk",
                    GeoLng = 53.94,
                    GeoLat = 27.55,           
                
                    AgeLimit = 16,
                }
            });

            context.Tickets.AddRange(new List<Ticket>
            {
                new Ticket()
                {
                    Id = ticketGuids[0],
                    UserId = Guid.Empty,
                    ConcertId = concertGuids[0],
                    IsConfirmed = true
                },
                new Ticket()
                {
                    Id = ticketGuids[1],
                    UserId = Guid.Empty,
                    ConcertId = concertGuids[0],
                    IsConfirmed = true
                },
                new Ticket()
                {
                    Id = ticketGuids[2],
                    UserId = Guid.Empty,
                    ConcertId = concertGuids[0],
                    IsConfirmed = true
                },
                new Ticket()
                {
                    Id = ticketGuids[3],
                    UserId = Guid.Empty,
                    ConcertId = concertGuids[2],
                    IsConfirmed = true
                },
                new Ticket()
                {
                    Id = ticketGuids[4],
                    UserId = Guid.Empty,
                    ConcertId = concertGuids[2],
                    IsConfirmed = true
                },
            });

            context.SaveChanges();
        }
    }
}
