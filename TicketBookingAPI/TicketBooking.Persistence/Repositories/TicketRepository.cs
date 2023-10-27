using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Persistence.Repositories
{
    internal sealed class TicketRepository: ITicketRepository
    {
        private readonly ITicketBookingDbContext _context;

        public TicketRepository(ITicketBookingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket ticket, CancellationToken cancellationToken)
        {
            await _context.Tickets.AddAsync(ticket, cancellationToken);
        }

        public void Delete(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
        }

        public async Task<List<Ticket>> GetByConcertIdAsync(Guid userId, Guid concertId, CancellationToken cancellationToken)
        {
            return await _context.Tickets
                .Where(t => t.UserId == userId && t.ConcertId == concertId)
                .ToListAsync(cancellationToken);
        }

        public async Task<Ticket> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Tickets.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<Ticket>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Tickets.Where(t => t.UserId == userId).ToListAsync(cancellationToken);
        }
    }
}
