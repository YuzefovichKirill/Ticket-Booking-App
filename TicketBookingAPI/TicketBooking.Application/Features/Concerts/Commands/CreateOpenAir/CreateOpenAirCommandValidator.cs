using FluentValidation;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateOpenAir
{
    public class CreateOpenAirCommandValidator : AbstractValidator<CreateOpenAirCommand>
    {
        public CreateOpenAirCommandValidator() 
        {
            RuleFor(createOpenAir => createOpenAir.ConcertName)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.BandName)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.AmountOfTickets)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(createOpenAir => createOpenAir.AmountOfAvailableTickets)
                .GreaterThanOrEqualTo(0);
            RuleFor(createOpenAir => createOpenAir.AmountOfAvailableTickets)
                .LessThanOrEqualTo(createOpenAir => createOpenAir.AmountOfTickets)
                .WithMessage("AmountOfAvailableTickets должно быть меньше или равно AmountOfTickets");
            RuleFor(createOpenAir => createOpenAir.DateTime)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.Place)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.GeoLng)
                .InclusiveBetween(-180, 180);
            RuleFor(createOpenAir => createOpenAir.GeoLat)
                .InclusiveBetween(-90, 90);
            RuleFor(createOpenAir => createOpenAir.ConcertType)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.Price)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.GettingHere)
                .NotEmpty();
            RuleFor(createOpenAir => createOpenAir.Headliner)
                .NotEmpty();
        }
    }
}
