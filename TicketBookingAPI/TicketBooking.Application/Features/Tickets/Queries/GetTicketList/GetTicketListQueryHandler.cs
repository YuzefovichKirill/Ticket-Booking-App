using MediatR;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicketList
{
    public class GetTicketListQueryHandler : IRequestHandler<GetTicketListQuery, TicketListVm>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IConcertRepository _concertRepository;

        public GetTicketListQueryHandler(ITicketRepository ticketRepository, IConcertRepository concertRepository)
        {
            _ticketRepository = ticketRepository;
            _concertRepository = concertRepository;
        }

        public async Task<TicketListVm> Handle(GetTicketListQuery request, CancellationToken cancellationToken)
        {
            var ticketsList = await _ticketRepository.GetByUserIdAsync(request.UserId, cancellationToken);
            var ConcertIds = ticketsList.Select(t => t.ConcertId).ToList();
            var concertsList = await _concertRepository.GetListByConcertIdsAsync(ConcertIds, cancellationToken);

            List<TicketVm> ticketVms = ticketsList.Join(concertsList, t => t.ConcertId, c => c.Id, (t, c) => new TicketVm()
            {
                Id = t.Id,
                ConcertId = t.ConcertId,
                ConcertName = c.ConcertName,
                ConcertTime = c.DateTime
            }).ToList();

            return new TicketListVm() { Tickets = ticketVms };
        }
    }
}
