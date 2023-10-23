using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Coupons.Commands.CreateCoupon;
using TicketBooking.Application.Features.Coupons.Commands.DeleteCoupon;
using TicketBooking.Application.Features.Coupons.Queries.GetCoupon;
using TicketBooking.Application.Features.Coupons.Queries.GetCouponList;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CouponController : BaseController
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CouponListVm>> GetAll()
        {
            var query = new GetCouponListQuery();
            var couponList = await Mediator.Send(query);
            return Ok(couponList);
        }

        [HttpGet("{name}")]
        [Authorize]
        public async Task<ActionResult<CouponListVm>> Get(string name)
        {
            var query = new GetCouponQuery() { UserId = UserId, Name = name };
            var coupon = await Mediator.Send(query);
            return Ok(coupon);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCouponCommand command)
        {
            var couponId = await Mediator.Send(command);
            return Ok(couponId);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteCouponCommand() { Id = id};
            var couponId = await Mediator.Send(command);
            return Ok(couponId);
        }
    }
}
