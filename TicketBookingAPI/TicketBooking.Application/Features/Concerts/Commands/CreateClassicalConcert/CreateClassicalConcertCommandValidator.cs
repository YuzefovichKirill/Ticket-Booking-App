using FluentValidation;

namespace TicketBooking.Application.Features.Concerts.Commands.CreateClassicalConcert
{
    public class CreateClassicalConcertCommandValidator : AbstractValidator<CreateClassicalConcertCommand>
    {
        public CreateClassicalConcertCommandValidator()
        {
            RuleFor(createClassicalConcert => createClassicalConcert.ConcertName)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.BandName)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.AmountOfTickets)
                .GreaterThan(0);
            RuleFor(createClassicalConcert => createClassicalConcert.AmountOfAvailableTickets)
                .GreaterThanOrEqualTo(0);
            RuleFor(createClassicalConcert => createClassicalConcert.AmountOfAvailableTickets)
                .LessThanOrEqualTo(createClassicalConcert => createClassicalConcert.AmountOfTickets)
                .WithMessage("AmountOfAvailableTickets должно быть меньше или равно AmountOfTickets");
            RuleFor(createClassicalConcert => createClassicalConcert.DateTime)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.Place)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.GeoLng)
                .InclusiveBetween(-180, 180);
            RuleFor(createClassicalConcert => createClassicalConcert.GeoLat)
                .InclusiveBetween(-90, 90);
            RuleFor(createClassicalConcert => createClassicalConcert.ConcertType)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.Price)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.Composer)
                .NotEmpty();
            RuleFor(createClassicalConcert => createClassicalConcert.VoiceType)
                .NotEmpty();
        }
    }
}
