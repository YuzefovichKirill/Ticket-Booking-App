using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Exceptions;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain;

namespace TicketBooking.Application.Features.Coupons.Commands.CreateCoupon
{
    internal class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, Guid>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public CreateCouponCommandHandler(ITicketBookingDbContext ticketBookingDbContext) => 
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task<Guid> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = _ticketBookingDbContext.Coupons.FirstOrDefault(c => c.Name == request.Name);

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

            await _ticketBookingDbContext.Coupons.AddAsync(coupon, cancellationToken);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
            return coupon.Id;
        }
    }
}
