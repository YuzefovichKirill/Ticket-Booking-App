using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicket
{
    public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, TicketVm>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly ITicketRepository _ticketRepository;

        public GetTicketQueryHandler(
            IConcertRepository concertRepository, 
            ITicketRepository ticketRepository)
        {
            _concertRepository = concertRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketVm> Handle(GetTicketQuery request, 
            CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetByConcertIdAsync(request.UserId, request.ConcertId, cancellationToken);

            if (!tickets.Any())
            {
                throw new NotFoundException("There is no such tickets");
            }

            var concert = await _concertRepository.GetByIdAsync(request.ConcertId, cancellationToken);

            if (concert is null)
            {
                throw new NotFoundException("There is no such concert");
            }

            string concertName = concert.ConcertName;
            DateTime concertTime = concert.DateTime;

            TicketVm ticketVm = new TicketVm()
            {
                ConcertId = request.ConcertId,
                ConcertName = concertName,
                ConcertTime = concertTime,
                AmountOfTickets = tickets.Count
            };
            return ticketVm;
        }
    }
}
