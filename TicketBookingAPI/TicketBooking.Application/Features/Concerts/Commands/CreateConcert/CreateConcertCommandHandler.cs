using MediatR;
using System.Text.Json;
using System.Windows.Input;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateConcert
{
    public class CreateConcertCommandHandler : IRequestHandler<CreateConcertCommand, Guid>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateConcertCommandHandler(
            IConcertRepository concertRepository, 
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

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

            await _concertRepository.AddAsync(concert, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}
