using MediatR;
using System.Text.Json;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateConcert
{
    public class CreateConcertCommandHandler : IRequestHandler<CreateConcertCommand, Guid>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public CreateConcertCommandHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<Guid> Handle(CreateConcertCommand request,
            CancellationToken cancellationToken)
        {
            string concertType = request.JsonObj["ConcertType"].ToString();
            Concert concert;
            switch (concertType)
            {
                case "ClassicalConcert":
                    /*concert = new ClassicalConcert()
                    {
                        Id = Guid.NewGuid(),
                        ConcertName = request.JsonObj["ConcertName"].ToString(),
                        BandName = request.JsonObj["BandName"].ToString(),
                        AmountOfTickets = Convert.ToInt32(request.JsonObj["AmountOfTickets"].ToString()),
                        AmountOfAvailableTickets = Convert.ToInt32(request.JsonObj["AmountOfAvailableTickets"].ToString()),
                        DateTime = new DateTime(Convert.ToInt64(request.JsonObj["DateTime"].ToString())),
                        Place = request.JsonObj["Place"].ToString(),
                        GeoLong = Convert.ToDouble(request.JsonObj["GeoLong"].ToString()),
                        GeoLat = Convert.ToDouble(request.JsonObj["GeoLat"].ToString()),
                        ConcertType = concertType,

                        VoiceType = request.JsonObj["VoiceType"].ToString(),
                        Composer = request.JsonObj["Composer"].ToString(),
                    };*/
                    concert = JsonSerializer.Deserialize<ClassicalConcert>(request.JsonObj);
                    break;
                case "OpenAir":
                    /*concert = new OpenAir()
                    {
                        Id = Guid.NewGuid(),
                        ConcertName = request.JsonObj["ConcertName"].ToString(),
                        BandName = request.JsonObj["BandName"].ToString(),
                        AmountOfTickets = Convert.ToInt32(request.JsonObj["AmountOfTickets"].ToString()),
                        AmountOfAvailableTickets = Convert.ToInt32(request.JsonObj["AmountOfAvailableTickets"].ToString()),
                        DateTime = new DateTime(Convert.ToInt64(request.JsonObj["DateTime"].ToString())),
                        Place = request.JsonObj["Place"].ToString(),
                        GeoLong = Convert.ToDouble(request.JsonObj["GeoLong"].ToString()),
                        GeoLat = Convert.ToDouble(request.JsonObj["GeoLat"].ToString()),
                        ConcertType = concertType,

                        GettingHere = request.JsonObj["GettingHere"].ToString(),
                        HeadLiner = request.JsonObj["HeadLiner"].ToString(),
                    };*/
                    concert = JsonSerializer.Deserialize<OpenAir>(request.JsonObj);
                    break;
                case "Party":
                    /*concert = new Party()
                    {
                        Id = Guid.NewGuid(),
                        ConcertName = request.JsonObj["ConcertName"].ToString(),
                        BandName = request.JsonObj["BandName"].ToString(),
                        AmountOfTickets = Convert.ToInt32(request.JsonObj["AmountOfTickets"].ToString()),
                        AmountOfAvailableTickets = Convert.ToInt32(request.JsonObj["AmountOfAvailableTickets"].ToString()),
                        DateTime = new DateTime(Convert.ToInt64(request.JsonObj["DateTime"].ToString())),
                        Place = request.JsonObj["Place"].ToString(),
                        GeoLong = Convert.ToDouble(request.JsonObj["GeoLong"].ToString()),
                        GeoLat = Convert.ToDouble(request.JsonObj["GeoLat"].ToString()),
                        ConcertType = concertType,

                        AgeLimit = Convert.ToInt32(request.JsonObj["AgeLimit"].ToString()),
                    };*/
                    concert = JsonSerializer.Deserialize<Party>(request.JsonObj);
                    break;
                default: 
                    throw new ArgumentException("There is no such concert type");
            }

            concert.Id = Guid.NewGuid();

            await _ticketBookingDbContext.Concerts.AddAsync(concert, cancellationToken);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}
