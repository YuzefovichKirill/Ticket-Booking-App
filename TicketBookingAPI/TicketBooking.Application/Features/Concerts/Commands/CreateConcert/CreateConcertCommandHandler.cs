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
            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            Concert concert;

            switch (concertType)
            {
                case nameof(ClassicalConcert):
                    concert = JsonSerializer.Deserialize<ClassicalConcert>(request.JsonObj, options);
                    break;
                case nameof(OpenAir):
                    concert = JsonSerializer.Deserialize<OpenAir>(request.JsonObj, options);
                    break;
                case nameof(Party):
                    concert = JsonSerializer.Deserialize<Party>(request.JsonObj, options);
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
