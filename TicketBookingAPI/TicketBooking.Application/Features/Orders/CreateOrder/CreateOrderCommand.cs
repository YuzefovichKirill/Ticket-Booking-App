using MediatR;

namespace TicketBooking.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public List<CouponDto> Coupons { get; set; }
    }
}
