using FluentValidation;

namespace TicketBooking.Application.Features.Tickets.Queries.GetTicketList
{
    public class GetTicketListQueryValidator : AbstractValidator<GetTicketListQuery>
    {
        public GetTicketListQueryValidator()
        {
            RuleFor(getTicketList => getTicketList.UserId)
                .NotEqual(Guid.Empty);
        }
    }
}
