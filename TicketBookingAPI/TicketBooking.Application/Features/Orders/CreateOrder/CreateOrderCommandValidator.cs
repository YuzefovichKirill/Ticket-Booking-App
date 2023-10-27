using FluentValidation;

namespace TicketBooking.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(createOrder => createOrder.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(createOrder => createOrder.Tickets)
                .Must(tickets => tickets.Count > 0)
                .WithMessage("Список билетов не должен быть пустым");
        }
    }
}
