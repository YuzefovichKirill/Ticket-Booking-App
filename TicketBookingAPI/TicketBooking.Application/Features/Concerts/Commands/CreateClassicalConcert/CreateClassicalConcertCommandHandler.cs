using MediatR;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateClassicalConcert
{
    public class CreateClassicalConcertCommandHandler : IRequestHandler<CreateClassicalConcertCommand, Guid>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateClassicalConcertCommandHandler(
            IConcertRepository concertRepository,
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateClassicalConcertCommand request,
            CancellationToken cancellationToken)
        {
            if (request.ConcertType != ConcertType.ClassicalConcert)
            {
                throw new ArgumentException("Wrong value", nameof(request.ConcertType));
            }

            ClassicalConcert concert = new ClassicalConcert()
            {
                Id = Guid.NewGuid(),
                ConcertName = request.ConcertName,
                BandName = request.BandName,
                AmountOfTickets = request.AmountOfTickets,
                AmountOfAvailableTickets = request.AmountOfAvailableTickets,
                DateTime = request.DateTime,
                Place = request.Place,
                GeoLng = request.GeoLng,
                GeoLat = request.GeoLat,
                Price = request.Price,
                Composer = request.Composer,
                VoiceType = request.VoiceType
            };

            await _concertRepository.AddAsync(concert, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}
