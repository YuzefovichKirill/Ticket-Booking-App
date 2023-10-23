using FluentValidation;

namespace TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponCommandValidator : AbstractValidator<DeleteCouponCommand>
    {
        public DeleteCouponCommandValidator() 
        {
            RuleFor(deleteCoupon => deleteCoupon.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
