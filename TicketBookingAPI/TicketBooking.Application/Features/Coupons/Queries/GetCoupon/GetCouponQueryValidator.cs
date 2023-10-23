using FluentValidation;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCoupon
{
    public class GetCouponQueryValidator : AbstractValidator<GetCouponQuery>
    {
        public GetCouponQueryValidator() 
        { 
            RuleFor(getCoupon => getCoupon.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(getCoupon => getCoupon.Name)
                .NotEmpty();
        }
    }
}
