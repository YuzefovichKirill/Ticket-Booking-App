using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCouponList
{
    public class GetCouponListQueryHandler : IRequestHandler<GetCouponListQuery, CouponListVm>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IConcertRepository _concertRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetCouponListQueryHandler(
            ICouponRepository couponRepository, 
            IConcertRepository concertRepository,
            IUnitOfWork unitOfWork)
        {
            _couponRepository = couponRepository;
            _concertRepository = concertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CouponListVm> Handle(GetCouponListQuery request, CancellationToken cancellationToken)
        {
            List<Coupon> coupons = await _couponRepository.GetListAsync(cancellationToken);

            var concertList = await _concertRepository.GetListAsync(cancellationToken);
            var concertInfos = concertList.Select(c => new { c.Id, c.ConcertName }).ToList();

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
