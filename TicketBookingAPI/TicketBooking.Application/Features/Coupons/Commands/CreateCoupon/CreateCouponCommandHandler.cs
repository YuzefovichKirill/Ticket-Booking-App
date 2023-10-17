using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Coupons.Commands.CreateCoupon
{
    internal class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, Guid>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCouponCommandHandler(
            ICouponRepository couponRepository, 
            IUnitOfWork unitOfWork)
        {
            _couponRepository = couponRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository.GetByNameAsync(request.Name, cancellationToken);

            if (coupon is not null)
            {
                throw new AlreadyUsedException("This coupon name is already used", coupon.Name);
            }

            coupon = new Coupon()
            {
                Id = Guid.NewGuid(),
                ConcertId = request.ConcertId,
                Name = request.Name,
                DiscountPercentage = request.DiscountPercentage
            };

            await _couponRepository.AddAsync(coupon, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return coupon.Id;
        }
    }
}
