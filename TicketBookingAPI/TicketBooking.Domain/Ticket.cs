using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid ConcertId { get; set; }
        public Guid UserId { get; set; }
    }
}
