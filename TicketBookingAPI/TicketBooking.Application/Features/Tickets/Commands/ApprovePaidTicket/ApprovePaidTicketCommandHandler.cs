﻿using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Commands.ApprovePaymentTicket
{
    public class ApprovePaidTicketCommandHandler: IRequestHandler<ApprovePaidTicketCommand>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApprovePaidTicketCommandHandler(
            ITicketRepository ticketRepository, 
            IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ApprovePaidTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.Id, cancellationToken);

            if (ticket is null)
            {
                throw new NotFoundException("There is no such ticket");
            }

            //ticket.IsPaid = true;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
