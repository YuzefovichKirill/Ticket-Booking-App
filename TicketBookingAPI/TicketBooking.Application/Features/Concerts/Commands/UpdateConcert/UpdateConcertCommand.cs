using MediatR;
using System.Text.Json.Nodes;

namespace TicketBooking.Application.Features.Concerts.Commands.UpdateConcert
{
    public class UpdateConcertCommand : IRequest
    {
        public JsonObject JsonObj { get; set; }
    }
}
