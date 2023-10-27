using FluentValidation;

namespace TicketBooking.Application.Features.Concerts.Commands.DeleteConcert
{
    public class DeleteConcertCommandValidator : AbstractValidator<DeleteConcertCommand>
    {
        public DeleteConcertCommandValidator() 
        { 
            RuleFor(deleteConcert => deleteConcert.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
