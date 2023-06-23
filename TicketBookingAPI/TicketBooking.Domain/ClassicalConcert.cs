using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Domain
{
    public class ClassicalConcert : Concert
    {
        public ClassicalConcert() { ConcertType = nameof(ClassicalConcert); }
        public string? VoiceType { get; set; }
        public string? Composer { get; set; }
    }
}
