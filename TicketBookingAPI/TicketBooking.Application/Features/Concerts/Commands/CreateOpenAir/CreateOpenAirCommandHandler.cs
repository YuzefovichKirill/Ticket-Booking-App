using MediatR;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateOpenAir
{
    public class CreateOpenAirCommandHandler : IRequestHandler<CreateOpenAirCommand, Guid>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOpenAirCommandHandler(
            IConcertRepository concertRepository,
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateOpenAirCommand request,
                CancellationToken cancellationToken)
        {
            object obj;
            if (!Enum.TryParse(typeof(ConcertType), request.ConcertType, true, out obj))
            {
                throw new ArgumentException("Wrong value", nameof(request.ConcertType));
            }

            ConcertType concertType = (ConcertType)obj;
            if (concertType != ConcertType.OpenAir)
            {
                throw new ArgumentException("Wrong value", nameof(request.ConcertType));
            }

            OpenAir concert = new OpenAir()
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
                GettingHere = request.GettingHere,
                Headliner = request.Headliner
            };

            await _concertRepository.AddAsync(concert, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}
