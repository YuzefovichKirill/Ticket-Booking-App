using FluentValidation;

namespace TicketBooking.Application.Features.Tickets.Commands.ApprovePaidTicket
{
    public class ApprovePaidTicketCommandValidator : AbstractValidator<ApprovePaidTicketCommand>
    {
        public ApprovePaidTicketCommandValidator()
        {
            RuleFor(approvePaidTicket => approvePaidTicket.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
