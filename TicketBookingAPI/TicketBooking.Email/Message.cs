using MimeKit;

namespace TicketBooking.Email
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid TicketId { get; set; }

        public Message(IEnumerable<string> to, string subject, string body, Guid ticketId)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("receiver", x)));
            Subject = subject;
            Body = body;
            TicketId = ticketId;
        }
    }
}
