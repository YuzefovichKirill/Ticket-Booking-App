using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Commands.DeleteTicket
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTicketCommandHandler(
            ITicketRepository ticketRepository, 
            IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTicketCommand request,
            CancellationToken cancellationToken)
        {
            Ticket ticket = await _ticketRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if (ticket is null)
            {
                throw new NotFoundException("There is no such ticket");
            }

            _ticketRepository.Delete(ticket);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
