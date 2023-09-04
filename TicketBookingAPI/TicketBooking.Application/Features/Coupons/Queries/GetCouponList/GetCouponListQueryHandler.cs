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
            
            return new CouponListVm() { Coupons = coupons }; 
        }
    }
}
