using FluentValidation;

namespace TicketBooking.Application.Features.Coupons.Commands.CreateCoupon
{
    public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponCommandValidator() 
        { 
            RuleFor(createCoupon => createCoupon.ConcertId)
                .NotEqual(Guid.Empty);
            RuleFor(createCoupon => createCoupon.Name)
                .NotEmpty();
            RuleFor(createCoupon => createCoupon.DiscountPercentage)
                .ExclusiveBetween(0, 100);
        }
    }
}
