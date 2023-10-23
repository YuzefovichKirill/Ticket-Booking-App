using MediatR;

namespace TicketBooking.Application.Features.Concerts.Commands.DeleteConcert
{
    public class DeleteConcertCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
