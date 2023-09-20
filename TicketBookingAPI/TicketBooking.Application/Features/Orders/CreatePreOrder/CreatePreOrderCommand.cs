using MediatR;
using TicketBooking.Application.Features.Orders.CreateOrder;

namespace TicketBooking.Application.Features.Orders.CreatePreOrder
{
    public class CreatePreOrderCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public List<CouponDto> Coupons { get; set; }
    }
}
