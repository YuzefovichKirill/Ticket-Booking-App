
namespace TicketBooking.Domain.Interfaces
{
    public interface ITicketRepository
    {
        public Task AddAsync(Ticket ticket, CancellationToken cancellationToken);
        public void Delete(Ticket ticket);
        public Task<Ticket> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<Ticket>> GetByConcertIdAsync(Guid userId, Guid concertId, CancellationToken cancellationToken);
        public Task<List<Ticket>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    }
}
