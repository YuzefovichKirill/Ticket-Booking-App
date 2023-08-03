using MediatR;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicketList
{
    public class GetTicketListQuery : IRequest<TicketListVm>
    {
        public Guid UserId { get; set; }
    }
}
