namespace TicketBooking.Application.Features.Orders.CreateOrder
{
    public class TicketDto
    {
        public Guid ConcertId { get; set; }
        public string ConcertName { get; set; }
        public int Quantity { get; set; }
    }
}
