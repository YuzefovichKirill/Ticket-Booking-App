using FluentValidation;

namespace TicketBooking.Application.Features.Orders.DeletePreOrder
{
    public class DeletePreOrderCommandValidator : AbstractValidator<DeletePreOrderCommand>
    {
        public DeletePreOrderCommandValidator()
        {
            RuleFor(deletePreOrder => deletePreOrder.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(deletePreOrder => deletePreOrder.Tickets)
                .NotEmpty();
        }
    }
}
