using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicketList
{
    public class TicketVm
    {
        public Guid Id { get; set; }
        public Guid ConcertId { get; set; }
        public string? ConcertName { get; set; }
        public DateTime ConcertTime { get; set; }
    }
}
