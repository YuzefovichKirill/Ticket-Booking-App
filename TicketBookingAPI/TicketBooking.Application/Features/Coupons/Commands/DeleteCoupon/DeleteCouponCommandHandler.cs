using MediatR;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain.Interfaces;

namespace TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponCommandHandler: IRequestHandler<DeleteCouponCommand>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCouponCommandHandler(
            ICouponRepository couponRepository, 
            IUnitOfWork unitOfWork)
        {
            _couponRepository = couponRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository.GetByIdAsync(request.Id, cancellationToken);
        
            if (coupon is null) 
            {
                throw new NotFoundException("There is no such coupon");
            }

            _couponRepository.Delete(coupon);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
