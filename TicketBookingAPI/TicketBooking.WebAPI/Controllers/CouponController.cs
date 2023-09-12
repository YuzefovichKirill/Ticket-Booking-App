using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Coupons.Commands.CreateCoupon;
using TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon;
using TicketBooking.Application.Features.Coupons.Queries.GetCoupon;
using TicketBooking.Application.Features.Coupons.Queries.GetCouponList;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class CouponController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CouponListVm>> GetAll()
        {
            var query = new GetCouponListQuery();
            var couponList = await Mediator.Send(query);
            return Ok(couponList);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CouponListVm>> Get(string name)
        {
            var query = new GetCouponQuery() { UserId = UserId, Name = name };
            var coupon = await Mediator.Send(query);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCouponCommand command)
        {
            var couponId = await Mediator.Send(command);
            return Ok(couponId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromHeader] DeleteCouponCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
