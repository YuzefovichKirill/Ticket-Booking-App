using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.Features.Coupons.Commands.CreateCoupon
{
    public class CreateCouponCommand: IRequest<Guid>
    {
        public Guid ConcertId { get; set; }
        public string? Name { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
