using MediatR;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Application.Features.Concerts.Commands.DeleteConcert
{
    public class DeleteConcertCommandHandler : IRequestHandler<DeleteConcertCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public DeleteConcertCommandHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(DeleteConcertCommand request,
            CancellationToken cancellationToken)
        {
            var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (concert == null)
            {
                throw new Exception("There is no concert in db with this id");
            }

            _ticketBookingDbContext.Concerts.Remove(concert);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
