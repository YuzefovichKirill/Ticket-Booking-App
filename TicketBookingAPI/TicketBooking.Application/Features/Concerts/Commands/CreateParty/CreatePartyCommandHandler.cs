using MediatR;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateParty
{
    public class CreatePartyCommandHandler : IRequestHandler<CreatePartyCommand, Guid>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePartyCommandHandler(
            IConcertRepository concertRepository,
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePartyCommand request,
            CancellationToken cancellationToken)
        {
            if (request.ConcertType != ConcertType.Party)
            {
                throw new ArgumentException("Wrong value", nameof(request.ConcertType));
            }

            Party concert = new Party()
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
                AgeLimit = request.AgeLimit
            };

            await _concertRepository.AddAsync(concert, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return concert.Id;
        }
    }
}