using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Orders.CreateOrder;
using TicketBooking.Application.Features.Orders.CreatePreOrder;
using TicketBooking.Application.Features.Orders.DeletePreOrder;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [Authorize]
    [ApiController]
    public class OrderController : BaseController
    {
        [HttpPost]
        [Route("pre-order")]
        public async Task<ActionResult> CreatePreOrder([FromBody] CreatePreOrderCommand command)
        {
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("pre-order")]
        public async Task<ActionResult> DeletePreorder([FromBody] DeletePreOrderCommand command)
        {
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
