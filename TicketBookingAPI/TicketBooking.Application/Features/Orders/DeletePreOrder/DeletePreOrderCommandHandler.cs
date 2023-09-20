using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Orders.DeletePreOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeletePreOrderCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public DeleteOrderCommandHandler(ITicketBookingDbContext ticketBookingDbContext)
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(DeletePreOrderCommand request, CancellationToken cancellationToken)
        {
            List<UsedCoupon> usedCoupons = new List<UsedCoupon>();
            foreach (var couponDto in request.Coupons)
            {
                var coupon = await _ticketBookingDbContext.Coupons.FindAsync(new object[] { couponDto.CouponId });
                if (coupon is null)
                {
                    continue;
                }

                var usedCoupon = await _ticketBookingDbContext.UsedCoupons.FirstOrDefaultAsync(uc => uc.UserId == request.UserId && uc.CouponId == couponDto.CouponId, cancellationToken);
                if (usedCoupon is not null)
                {
                    usedCoupons.Add(usedCoupon);
                }
            }
            _ticketBookingDbContext.UsedCoupons.RemoveRange(usedCoupons);

            foreach (var ticketDto in request.Tickets)
            {
                var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { ticketDto.ConcertId });
                if (concert is null)
                {
                    continue;
                }
                concert.AmountOfAvailableTickets += ticketDto.Quantity;
            }

            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
