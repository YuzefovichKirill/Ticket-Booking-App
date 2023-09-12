using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBooking.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public bool IsPaid { get; set; } = false;

        [ForeignKey(nameof(Concert))]
        public Guid ConcertId { get; set; }
        public Concert Concert { get; set; }

    }
}
