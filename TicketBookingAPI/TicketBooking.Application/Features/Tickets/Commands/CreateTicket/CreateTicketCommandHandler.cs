using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Features.Orders.CreateOrder;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(
            ITicketRepository ticketRepository,
            IConcertRepository concertRepository, 
            IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketCommand request, 
            CancellationToken cancellationToken)
        {
            var concert = await _concertRepository.GetByIdAsync(request.ConcertId, cancellationToken);

            if (concert is null)
            {
                throw new NotFoundException("There is no such concert");
            }
            if (concert.AmountOfAvailableTickets == 0) 
            {
                throw new NotEnoughTicketsException($"There is no available tickets for this concert ({1} for concert { concert.ConcertName})");
            }
            else
            {
                concert.AmountOfAvailableTickets -= 1;
            }

            Ticket ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                ConcertId = request.ConcertId,
            };

            await _ticketRepository.AddAsync(ticket, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return ticket.Id;
        }
    }
}
