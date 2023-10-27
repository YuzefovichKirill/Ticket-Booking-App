using FluentValidation;

namespace TicketBooking.Application.Features.Orders.CreatePreOrder
{
    public class CreatePreOrderCommandValidator : AbstractValidator<CreatePreOrderCommand>
    {
        public CreatePreOrderCommandValidator()
        {
            RuleFor(createPreOrder => createPreOrder.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(createPreOrder => createPreOrder.Tickets)
                .Must(tickets => tickets != null && tickets.Any())
                .WithMessage("Список билетов не должен быть пустым");

        }
    }
}
