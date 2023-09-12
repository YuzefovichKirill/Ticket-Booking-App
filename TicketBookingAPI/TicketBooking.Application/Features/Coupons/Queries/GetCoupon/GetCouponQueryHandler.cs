using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Features.Orders.CreateOrder;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCoupon
{
    public class GetCouponQueryHandler : IRequestHandler<GetCouponQuery, Coupon>
    {
        private ITicketBookingDbContext _ticketBookingDbContext;

        public GetCouponQueryHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<Coupon> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _ticketBookingDbContext.Coupons.FirstOrDefaultAsync(c => c.Name == request.Name, cancellationToken);

            if (coupon is null) 
            {
                throw new Exception($"There is no such coupon (Coupon name: {request.Name})");
            }

            var usedCoupon = await _ticketBookingDbContext.UsedCoupons.FirstOrDefaultAsync(uc => uc.UserId == request.UserId && uc.Id == coupon.Id, cancellationToken);

            if (usedCoupon is not null)
            {
                throw new Exception($"This coupon is already used (Coupon name: {coupon.Name})");
            }

            return coupon;
        }
    }
}
