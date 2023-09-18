using MediatR;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using System.Text.Json;
using TicketBooking.Application.Exceptions;

namespace TicketBooking.Application.Features.Concerts.Commands.UpdateConcert
{
    public class UpdateConcertCommandHandler : IRequestHandler<UpdateConcertCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public UpdateConcertCommandHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(UpdateConcertCommand request,
            CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(request.JsonObj["Id"].ToString());
            var dbConcert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { id }, cancellationToken);

            if (dbConcert is null)
            {
                throw new NotFoundException("There is no such concert");
            }

            string? concertType = request?.JsonObj["ConcertType"]?.ToString();
            if (concertType is null)
            {
                throw new ArgumentNullException(nameof(concertType));
            }

            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            Concert concert;

            switch (concertType)
            {
                case nameof(ClassicalConcert):
                    var classicalConcert = JsonSerializer.Deserialize<ClassicalConcert>(request.JsonObj, options);
                    concert = classicalConcert;
                    var dbClassicalConcert = dbConcert as ClassicalConcert;
                    dbClassicalConcert.VoiceType = classicalConcert.VoiceType;
                    dbClassicalConcert.Composer = classicalConcert.Composer;
                    break;
                case nameof(OpenAir):
                    var openAir = JsonSerializer.Deserialize<OpenAir>(request.JsonObj, options);
                    concert = openAir;
                    var dbOpenAir = dbConcert as OpenAir;
                    dbOpenAir.Headliner = openAir.Headliner;
                    dbOpenAir.GettingHere = openAir.GettingHere;
                    break;
                case nameof(Party):
                    var party = JsonSerializer.Deserialize<Party>(request.JsonObj, options);
                    concert = party;
                    var dbParty = dbConcert as Party;
                    dbParty.AgeLimit = party.AgeLimit;
                    break;
                default: 
                    throw new ArgumentException($"There is no such concert type ({concertType})");
            }

            dbConcert.AmountOfAvailableTickets = concert.AmountOfAvailableTickets;
            dbConcert.AmountOfTickets = concert.AmountOfTickets;
            dbConcert.BandName = concert.BandName;
            dbConcert.ConcertName = concert.ConcertName;
            dbConcert.DateTime = concert.DateTime;
            dbConcert.GeoLat = concert.GeoLat;
            dbConcert.GeoLng = concert.GeoLng;
            dbConcert.Place = concert.Place;

            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
