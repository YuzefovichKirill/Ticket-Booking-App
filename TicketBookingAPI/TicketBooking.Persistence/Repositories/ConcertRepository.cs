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
            var concerts = await _context.Concerts.ToListAsync();
            if (!Enum.TryParse(concertType, out ConcertType eConcertType) && !String.IsNullOrEmpty(concertType))
            {
                throw new ArgumentException("Wrong concertType name", nameof(concertType));
            }

            if (!String.IsNullOrEmpty(containsInName) && !String.IsNullOrEmpty(concertType))
            {
                return concerts
                    .Where(c => c.ConcertName.Contains(containsInName) && c.ConcertType == eConcertType)
                    .ToList();
            }
            else if (!String.IsNullOrEmpty(containsInName))
            {
                return concerts
                    .Where(c => c.ConcertName.Contains(containsInName))
                    .ToList();                   
            }
            else if (!String.IsNullOrEmpty(concertType))
            {
                return concerts
                    .Where(c => c.ConcertType == eConcertType)
                    .ToList();
            }
            return concerts;
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
