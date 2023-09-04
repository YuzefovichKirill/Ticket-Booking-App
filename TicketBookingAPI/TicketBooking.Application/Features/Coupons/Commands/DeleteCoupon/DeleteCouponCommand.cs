using MediatR;

namespace TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
