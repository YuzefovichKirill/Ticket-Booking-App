using FluentValidation;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcert
{
    public class GetConcertQueryValidator : AbstractValidator<GetConcertQuery>
    {
        public GetConcertQueryValidator()
        {
            RuleFor(getConcert => getConcert.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
