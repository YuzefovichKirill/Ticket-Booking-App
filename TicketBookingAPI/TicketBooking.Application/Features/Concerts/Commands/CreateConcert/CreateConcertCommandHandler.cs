using MediatR;
using System.Text.Json;
using TicketBooking.Application.Exceptions;
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
            string? concertType = request?.JsonObj["ConcertType"]?.ToString();

            if (concertType is null)
            {
                throw new ArgumentNullException(nameof(concertType));
            }

            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            
            Concert concert = concertType switch
            {
                nameof(ClassicalConcert) => JsonSerializer.Deserialize<ClassicalConcert>(request.JsonObj, options),
                nameof(OpenAir) => JsonSerializer.Deserialize<OpenAir>(request.JsonObj, options),
                nameof(Party) => JsonSerializer.Deserialize<Party>(request.JsonObj, options),
                _ => throw new ArgumentException("There is no such concert type"),
            };
            concert.Id = Guid.NewGuid();

            await _ticketBookingDbContext.Concerts.AddAsync(concert, cancellationToken);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}
