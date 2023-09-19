using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCouponList
{
    public class GetCouponListQueryHandler : IRequestHandler<GetCouponListQuery, CouponListVm>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public GetCouponListQueryHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<CouponListVm> Handle(GetCouponListQuery request, CancellationToken cancellationToken)
        {
            List<Coupon> coupons = await _ticketBookingDbContext.Coupons.ToListAsync();
            
            var concertInfos = await _ticketBookingDbContext.Concerts.Select(c => new { c.Id, c.ConcertName }).ToListAsync();

            List<CouponVm> couponVms = coupons
                .Join(concertInfos,
                     coupon => coupon.ConcertId,
                     concertInfo => concertInfo.Id, 
                     (coupon, concertInfo) =>
                         new CouponVm()
                         {
                             Id = coupon.Id,
                             ConcertName = concertInfo.ConcertName,
                             DiscountPercentage = coupon.DiscountPercentage,
                             Name = coupon.Name
                         }).ToList();

            return new CouponListVm() { Coupons = couponVms }; 
        }
    }
}
