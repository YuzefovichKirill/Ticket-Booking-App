using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcertList
{
    public class ConcertDto
    {
        public Guid Id { get; set; }
        public string? ConcertName { get; set; }
        public string? BandName { get; set; }
        public int AmountOfAvailableTickets { get; set; }
        public DateTime DateTime { get; set; }
        public string? Place { get; set; }
        public string? ConcertType { get; set; }

    }
}
