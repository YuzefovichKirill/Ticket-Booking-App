using MediatR;

namespace TicketBooking.Application.Features.Coupons.Commands.CreateCoupon
{
    public class CreateCouponCommand: IRequest<Guid>
    {
        public Guid ConcertId { get; set; }
        public string? Name { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
