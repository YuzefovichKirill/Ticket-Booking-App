﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Features.Orders.CreateOrder;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public CreateTicketCommandHandler(ITicketBookingDbContext ticketBookingDbContext) 
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<Guid> Handle(CreateTicketCommand request, 
            CancellationToken cancellationToken)
        {
            var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { request.ConcertId });

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

            await _ticketBookingDbContext.Tickets.AddAsync(ticket, cancellationToken);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
            return ticket.Id;
        }
    }
}
