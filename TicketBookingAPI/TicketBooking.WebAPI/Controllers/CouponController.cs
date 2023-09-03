using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Coupons.Commands.CreateCoupon;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : BaseController
    {
        [HttpPost]
        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetAll([FromBody] CreateCouponCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
