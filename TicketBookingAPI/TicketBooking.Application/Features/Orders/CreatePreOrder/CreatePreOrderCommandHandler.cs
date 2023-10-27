using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Orders.CreatePreOrder
{
    public class CreatePreOrderCommandHandler : IRequestHandler<CreatePreOrderCommand, int>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IConcertRepository _concertRepository;
        private readonly IUsedCouponRepository _usedCouponRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePreOrderCommandHandler(
            ICouponRepository couponRepository,
            IConcertRepository concertRepository,
            IUsedCouponRepository usedCouponRepository,
            IUnitOfWork unitOfWork)
        {
            _couponRepository = couponRepository;
            _concertRepository = concertRepository;
            _usedCouponRepository = usedCouponRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePreOrderCommand request, CancellationToken cancellationToken)
        {
            foreach (var couponDto in request.Coupons)
            {
                var coupon = await _couponRepository.GetByIdAsync(couponDto.CouponId, cancellationToken);
                if (coupon is null)
                {
                    throw new NotFoundException($"There is no such coupon (Coupon name: {couponDto.Name})");
                }

                var usedCoupon = await _usedCouponRepository.GetByCouponIdAsync(request.UserId, couponDto.CouponId, cancellationToken);
                if (usedCoupon is not null)
                {
                    throw new AlreadyUsedException($"This coupon is already used", couponDto.Name);
                }

                var newUsedCoupon = new UsedCoupon()
                {
                    Id = Guid.NewGuid(),
                    CouponId = couponDto.CouponId,
                    UserId = request.UserId
                };

                await _usedCouponRepository.AddAsync(newUsedCoupon, cancellationToken);
            }

            foreach (var ticketDto in request.Tickets)
            {
                var concert = await _concertRepository.GetByIdAsync(ticketDto.ConcertId, cancellationToken);

                if (concert is null)
                {
                    throw new NotFoundException($"There is no such concert (Concert name: {ticketDto.ConcertName})");
                }

                if (concert.AmountOfAvailableTickets < ticketDto.Quantity)
                {
                    throw new NotEnoughTicketsException($"There is no such quantity of available tickets for this concert ({ticketDto.Quantity} for concert {ticketDto.ConcertName})");
                }
                else
                {
                    concert.AmountOfAvailableTickets -= ticketDto.Quantity;
                }
            }

            var res = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return res;
        }
    }
}
