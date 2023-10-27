using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Application.Features.Coupons.Queries.GetCouponList
{
    public class CouponVm
    {
        public Guid Id { get; set; }
        public string? ConcertName { get; set; }
        public string? Name { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
