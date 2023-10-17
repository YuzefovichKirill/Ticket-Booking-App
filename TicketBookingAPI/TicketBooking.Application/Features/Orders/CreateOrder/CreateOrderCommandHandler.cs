using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(
            IConcertRepository concertRepository,
            ITicketRepository ticketRepository,
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            foreach (var ticketDto in request.Tickets)
            {
                var concert = await _concertRepository.GetByIdAsync(ticketDto.ConcertId, cancellationToken);

                if (concert is null)
                {
                    throw new NotFoundException($"There is no such concert (Concert name: {ticketDto.ConcertName})");
                }

                for (int i =  0; i < ticketDto.Quantity; i++)
                {
                    await _ticketRepository.AddAsync(new Ticket() 
                    { 
                        Id = Guid.NewGuid(),
                        UserId = request.UserId,
                        ConcertId = ticketDto.ConcertId,
                    }, cancellationToken);
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

    }
}
