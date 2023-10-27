using MediatR;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCoupon
{
    public class GetCouponQuery: IRequest<Coupon>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
