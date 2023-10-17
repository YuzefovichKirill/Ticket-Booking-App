using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Persistence.Repositories
{
    internal sealed class ConcertRepository: IConcertRepository
    {
        private readonly ITicketBookingDbContext _context;

        public ConcertRepository(ITicketBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Concert concert, CancellationToken cancellationToken)
        {
            await _context.Concerts.AddAsync(concert, cancellationToken);
        }

        public void Delete(Concert concert)
        {
            _context.Concerts.Remove(concert);
        }

        public async Task<Concert> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
           return await _context.Concerts.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<Concert>> GetListWithFiltersAsync(string? containsInName, string? concertType, CancellationToken cancellationToken)
        {
            if (!String.IsNullOrEmpty(containsInName) && !String.IsNullOrEmpty(concertType))
            {
                return _context.Concerts
                    .AsEnumerable()
                    .Where(c => c.ConcertName.Contains(containsInName) && String.Equals(c.ConcertType, concertType, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else if (!String.IsNullOrEmpty(containsInName))
            {
                return await _context.Concerts
                    .Where(c => c.ConcertName.Contains(containsInName))
                    .ToListAsync(cancellationToken);
            }
            else if (!String.IsNullOrEmpty(concertType))
            {
                return _context.Concerts
                    .AsEnumerable().Where(c => c.ConcertType == concertType)
                    .ToList();
            }
            
            return await _context.Concerts.ToListAsync(cancellationToken);
        }

        public async Task<List<Concert>> GetListAsync(CancellationToken cancellationToken)
        {
            return await _context.Concerts.ToListAsync(cancellationToken);
        }

        public async Task<List<Concert>> GetListByConcertIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            return await _context.Concerts.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
    }
}
