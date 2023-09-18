using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Concerts.Queries.GetConcert
{
    public class GetConcertQueryHandler : IRequestHandler<GetConcertQuery, Concert>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public GetConcertQueryHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<Concert> Handle(GetConcertQuery request, CancellationToken cancellationToken)
        {
            var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { request.Id });

            if (concert is null)
            {
                throw new NotFoundException("There is no such concert");
            }

            switch (concert.ConcertType)
            {
                case nameof(ClassicalConcert):
                    return concert as ClassicalConcert;
                case nameof(OpenAir):
                    return concert as OpenAir;
                case nameof(Party):
                    return concert as Party;
                default:
                    throw new ArgumentException("There is no such concert type");
            }
        }
    }
}
