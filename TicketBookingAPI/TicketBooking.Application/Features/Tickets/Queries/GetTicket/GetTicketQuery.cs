using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicket
{
    public class GetTicketQuery : IRequest<TicketVm>
    {
        public Guid UserId { get; set; }
        public Guid ConcertId { get; set; }
    }
}
