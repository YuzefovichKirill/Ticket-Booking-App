using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.Exceptions
{
    public class NotEnoughTicketsException : Exception
    {
        public NotEnoughTicketsException(string message) : base(message) { }
    }
}
