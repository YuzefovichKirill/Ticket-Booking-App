using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Orders.CreateOrder;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [Authorize]
    [ApiController]
    public class OrderController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
        {
            command.UserId = UserId;
            await Mediator.Send(command);
            return Ok();
        }
    }
}
