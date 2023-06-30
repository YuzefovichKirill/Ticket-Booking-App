using MediatR;
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
            string concertType = request.jsonObj["ConcertType"].ToString();
            Concert concert;
            switch (concertType)
            {
                case "ClassicalConcert":
                    concert = new ClassicalConcert()
                    {
                        Id = Guid.NewGuid(),
                        ConcertName = request.jsonObj["ConcertName"].ToString(),
                        BandName = request.jsonObj["BandName"].ToString(),
                        AmountOfTickets = Convert.ToInt32(request.jsonObj["AmountOfTickets"].ToString()),
                        AmountOfAvailableTickets = Convert.ToInt32(request.jsonObj["AmountOfAvailableTickets"].ToString()),
                        DateTime = new DateTime(Convert.ToInt64(request.jsonObj["DateTime"].ToString())),
                        Place = request.jsonObj["Place"].ToString(),
                        GeoLong = Convert.ToDouble(request.jsonObj["GeoLong"].ToString()),
                        GeoLat = Convert.ToDouble(request.jsonObj["GeoLat"].ToString()),
                        ConcertType = concertType,

                        VoiceType = request.jsonObj["VoiceType"].ToString(),
                        Composer = request.jsonObj["Composer"].ToString(),
                    };
                    break;
                case "OpenAir":
                    concert = new OpenAir()
                    {
                        Id = Guid.NewGuid(),
                        ConcertName = request.jsonObj["ConcertName"].ToString(),
                        BandName = request.jsonObj["BandName"].ToString(),
                        AmountOfTickets = Convert.ToInt32(request.jsonObj["AmountOfTickets"].ToString()),
                        AmountOfAvailableTickets = Convert.ToInt32(request.jsonObj["AmountOfAvailableTickets"].ToString()),
                        DateTime = new DateTime(Convert.ToInt64(request.jsonObj["DateTime"].ToString())),
                        Place = request.jsonObj["Place"].ToString(),
                        GeoLong = Convert.ToDouble(request.jsonObj["GeoLong"].ToString()),
                        GeoLat = Convert.ToDouble(request.jsonObj["GeoLat"].ToString()),
                        ConcertType = concertType,

                        GettingHere = request.jsonObj["GettingHere"].ToString(),
                        HeadLiner = request.jsonObj["HeadLiner"].ToString(),
                    };
                    break;
                case "Party":
                    concert = new Party()
                    {
                        Id = Guid.NewGuid(),
                        ConcertName = request.jsonObj["ConcertName"].ToString(),
                        BandName = request.jsonObj["BandName"].ToString(),
                        AmountOfTickets = Convert.ToInt32(request.jsonObj["AmountOfTickets"].ToString()),
                        AmountOfAvailableTickets = Convert.ToInt32(request.jsonObj["AmountOfAvailableTickets"].ToString()),
                        DateTime = new DateTime(Convert.ToInt64(request.jsonObj["DateTime"].ToString())),
                        Place = request.jsonObj["Place"].ToString(),
                        GeoLong = Convert.ToDouble(request.jsonObj["GeoLong"].ToString()),
                        GeoLat = Convert.ToDouble(request.jsonObj["GeoLat"].ToString()),
                        ConcertType = concertType,

                        AgeLimit = Convert.ToInt32(request.jsonObj["AgeLimit"].ToString()),
                    };
                    break;
                default: return Guid.Empty;
            }

            await _ticketBookingDbContext.Concerts.AddAsync(concert, cancellationToken);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}
