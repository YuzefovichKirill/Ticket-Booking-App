using MediatR;

namespace TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
