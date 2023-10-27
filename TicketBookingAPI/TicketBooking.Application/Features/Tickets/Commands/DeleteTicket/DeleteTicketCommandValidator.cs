using FluentValidation;

namespace TicketBooking.Application.Features.Tickets.Commands.DeleteTicket
{
    public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
    {
        public DeleteTicketCommandValidator()
        {
            RuleFor(deleteTicket => deleteTicket.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
