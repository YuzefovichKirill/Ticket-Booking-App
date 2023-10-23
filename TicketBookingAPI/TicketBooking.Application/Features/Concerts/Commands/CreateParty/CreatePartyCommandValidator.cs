using FluentValidation;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateParty
{
    public class CreatePartyCommandValidator : AbstractValidator<CreatePartyCommand>
    {
        public CreatePartyCommandValidator()
        {
            RuleFor(createParty => createParty.ConcertName)
                .NotEmpty();
            RuleFor(createParty => createParty.BandName)
                .NotEmpty();
            RuleFor(createParty => createParty.AmountOfTickets)
                .GreaterThan(0);
            RuleFor(createParty => createParty.AmountOfAvailableTickets)
                .GreaterThanOrEqualTo(0);
            RuleFor(createParty => createParty.AmountOfAvailableTickets)
                .LessThanOrEqualTo(createParty => createParty.AmountOfTickets)
                .WithMessage("AmountOfAvailableTickets должно быть меньше или равно AmountOfTickets");
            RuleFor(createParty => createParty.DateTime)
                .NotEmpty();
            RuleFor(createParty => createParty.Place)
                .NotEmpty();
            RuleFor(createParty => createParty.GeoLng)
                .InclusiveBetween(-180, 180);
            RuleFor(createParty => createParty.GeoLat)
                .InclusiveBetween(-90, 90);
            RuleFor(createParty => createParty.ConcertType)
                .NotEmpty();
            RuleFor(createParty => createParty.Price)
                .NotEmpty();
            RuleFor(createParty => createParty.AgeLimit)
                .InclusiveBetween(0, 100);
        }
    }
}
