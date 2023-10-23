using FluentValidation;

namespace TicketBooking.Application.Features.Tickets.Commands.CreateTicket
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(createTicket => createTicket.ConcertId)
                .NotEqual(Guid.Empty);
            RuleFor(createTicket => createTicket.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
