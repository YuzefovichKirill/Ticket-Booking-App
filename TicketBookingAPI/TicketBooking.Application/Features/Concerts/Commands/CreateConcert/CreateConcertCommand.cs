using MediatR;
using System.Text.Json.Nodes;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateConcert
{
    public class CreateConcertCommand : IRequest<Guid>
    {
        public JsonObject jsonObj { get; set; }
    }
}
