using FluentValidation;

namespace TicketBooking.Application.Features.Tickets.Commands.ConfirmTicket
{
    public class ConfirmTicketCommandValidator : AbstractValidator<ConfirmTicketCommand>
    {
        public ConfirmTicketCommandValidator()
        {
            RuleFor(confirmTicket => confirmTicket.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
