using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Features.Orders.CreateOrder;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCoupon
{
    public class GetCouponQueryHandler : IRequestHandler<GetCouponQuery, Coupon>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IUsedCouponRepository _usedCouponRepository;

        public GetCouponQueryHandler(
            ICouponRepository couponRepository, 
            IUsedCouponRepository usedCouponRepository)
        {
            _couponRepository = couponRepository;
            _usedCouponRepository = usedCouponRepository;
        }

        public async Task<Coupon> Handle(GetCouponQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository.GetByNameAsync(request.Name, cancellationToken);
            if (coupon is null) 
            {
                throw new NotFoundException($"There is no such coupon (Coupon name: {request.Name})");
            }

            var usedCoupon = await _usedCouponRepository.GetByCouponIdAsync(request.UserId, coupon.Id, cancellationToken);
            if (usedCoupon is not null)
            {
                throw new AlreadyUsedException($"This coupon is already used", coupon.Name);
            }

            return coupon;
        }
    }
}
