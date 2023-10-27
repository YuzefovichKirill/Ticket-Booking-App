using FluentValidation;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicket
{
    public class GetTicketQueryValidator : AbstractValidator<GetTicketQuery>
    {
        public GetTicketQueryValidator()
        {
            RuleFor(getTicket => getTicket.UserId)
                .NotEqual(Guid.Empty);
            RuleFor(getTicket => getTicket.ConcertId)
                .NotEqual(Guid.Empty);
        }
    }
}
