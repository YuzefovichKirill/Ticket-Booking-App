namespace TicketBooking.Domain.Interfaces
{
    public interface IConcertRepository
    {
        public Task AddAsync(Concert concert, CancellationToken cancellationToken);
        public void Delete(Concert concert);
        public Task<Concert> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<List<Concert>> GetListAsync(CancellationToken cancellationToken);
        public Task<List<Concert>> GetListByConcertIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
        public Task<List<Concert>> GetListWithFiltersAsync(string? containsInName, string? concertType, CancellationToken cancellationToken);
    }
}
