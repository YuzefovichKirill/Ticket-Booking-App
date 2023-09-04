using MediatR;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon
{
    public class DeleteCouponCommandHandler: IRequestHandler<DeleteCouponCommand>
    {
        private readonly ITicketBookingDbContext _ticketBookingDbContext;

        public DeleteCouponCommandHandler(ITicketBookingDbContext ticketBookingDbContext) =>
            _ticketBookingDbContext = ticketBookingDbContext;

        public async Task Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
        {
            var coupon = await _ticketBookingDbContext.Coupons.FindAsync(new object[] { request.Id }, cancellationToken);
        
            if (coupon is null) 
            {
                throw new Exception("There is no coupon in db with this id");
            }

            _ticketBookingDbContext.Coupons.Remove(coupon);
            await _ticketBookingDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
