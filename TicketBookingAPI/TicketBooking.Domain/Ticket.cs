using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Concert))]
        public Guid ConcertId { get; set; }
        public Concert Concert { get; set; }
        public Guid UserId { get; set; }
    }
}
