using MediatR;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Orders.DeletePreOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeletePreOrderCommand, int>
    {
        private readonly IConcertRepository _concertRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IUsedCouponRepository _usedCouponRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(
            IConcertRepository concertRepository, 
            ICouponRepository couponRepository, 
            IUsedCouponRepository usedCouponRepository, 
            IUnitOfWork unitOfWork)
        {
            _concertRepository = concertRepository;
            _couponRepository = couponRepository;
            _usedCouponRepository = usedCouponRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeletePreOrderCommand request, CancellationToken cancellationToken)
        {
            List<UsedCoupon> usedCoupons = new List<UsedCoupon>();
            foreach (var couponDto in request.Coupons)
            {
                var coupon = await _couponRepository.GetByIdAsync(couponDto.CouponId, cancellationToken);
                if (coupon is null)
                {
                    continue;
                }

                var usedCoupon = await _usedCouponRepository.GetByCouponIdAsync(request.UserId, couponDto.CouponId, cancellationToken);
                if (usedCoupon is not null)
                {
                    usedCoupons.Add(usedCoupon);
                }
            }
            _usedCouponRepository.DeleteRange(usedCoupons);

            foreach (var ticketDto in request.Tickets)
            {
                var concert = await _concertRepository.GetByIdAsync(ticketDto.ConcertId, cancellationToken);
                if (concert is null)
                {
                    continue;
                }
                concert.AmountOfAvailableTickets += ticketDto.Quantity;
            }

            var res = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return res;
        }
    }
}
