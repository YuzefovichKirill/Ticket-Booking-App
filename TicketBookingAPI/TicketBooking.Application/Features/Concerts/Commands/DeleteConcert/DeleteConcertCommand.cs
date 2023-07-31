using MediatR;

namespace TicketBooking.Application.Features.Concerts.Commands.DeleteConcert
{
    public class DeleteConcertCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
