using MediatR;
using TicketBooking.Application.Features.Orders.CreateOrder;

namespace TicketBooking.Application.Features.Orders.DeletePreOrder
{
    public class DeletePreOrderCommand : IRequest<int>
    {
        public Guid UserId { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public List<CouponDto> Coupons { get; set; }
    }
}
