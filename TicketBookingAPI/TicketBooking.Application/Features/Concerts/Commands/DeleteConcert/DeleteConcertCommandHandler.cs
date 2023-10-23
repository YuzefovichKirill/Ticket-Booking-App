using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Commands.DeleteConcert
{
    public class DeleteConcertCommandHandler : IRequestHandler<DeleteConcertCommand, Guid>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConcertCommandHandler(
            IConcertRepository concertRepository, 
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteConcertCommand request,
            CancellationToken cancellationToken)
        {
            var concert = await _concertRepository.GetByIdAsync(request.Id, cancellationToken);

            if (concert is null)
            {
                throw new NotFoundException($"There is no such concert");
            }

            _concertRepository.Delete(concert);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
