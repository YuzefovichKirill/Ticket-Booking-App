using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public CreateOrderCommandHandler(ITicketBookingDbContext ticketBookingDbContext)
            => _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            foreach (var couponDto in request.Coupons)
            {
                var coupon = await _ticketBookingDbContext.Coupons.FindAsync(new object[] { couponDto.CouponId });
                if (coupon is null)
                {
                    throw new Exception($"There is no such coupon (Coupon name: {couponDto.Name})");
                }

                var usedCoupon = await _ticketBookingDbContext.UsedCoupons.FirstOrDefaultAsync(uc => uc.UserId == request.UserId && uc.Id == couponDto.CouponId, cancellationToken);
                if (usedCoupon is not null)
                {
                    throw new Exception($"This coupon is already used (Coupon name: {couponDto.Name})");
                }

                var newUsedCoupon = new UsedCoupon()
                {
                    Id = Guid.NewGuid(),
                    CouponId = couponDto.CouponId,
                    UserId = request.UserId
                };

                await _ticketBookingDbContext.UsedCoupons.AddAsync(newUsedCoupon, cancellationToken);
            }

            foreach (var ticketDto in request.Tickets)
            {
                var concert = await _ticketBookingDbContext.Concerts.FindAsync(new object[] { ticketDto.ConcertId });

                if (concert is null)
                {
                    throw new Exception($"There is no such concert (Concert name: {ticketDto.ConcertName})");
                }

                if (concert.AmountOfAvailableTickets < ticketDto.Quantity)
                {
                    throw new Exception($"There is no such quantity of available tickets for this concert ({ticketDto.Quantity} for concert {ticketDto.ConcertName})");
                }
                else
                {
                    concert.AmountOfAvailableTickets -= ticketDto.Quantity;
                }

                for (int i =  0; i < ticketDto.Quantity; i++)
                {
                    await _ticketBookingDbContext.Tickets.AddAsync(new Ticket() 
                    { 
                        Id = Guid.NewGuid(),
                        UserId = request.UserId,
                        IsConfirmed = false,
                        IsPaid = true,
                        ConcertId = ticketDto.ConcertId,
                    }, cancellationToken);
                }
            }

            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
