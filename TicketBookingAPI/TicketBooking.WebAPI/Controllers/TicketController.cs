using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Tickets.Commands.CreateTicket;
using TicketBooking.Application.Features.Tickets.Commands.DeleteTicket;
using TicketBooking.Application.Features.Tickets.Queries.GetTicket;
using TicketBooking.Application.Features.Tickets.Queries.GetTicketList;

namespace TicketBooking.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]s")]
    public class TicketController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TicketListVm>> GetAll()
        {
            var query = new GetTicketListQuery() { UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketVm>> Get(Guid concertId)
        {
            var query = new GetTicketQuery() { UserId = UserId, ConcertId = concertId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] Guid concertId)
        {
            var command = new CreateTicketCommand() { UserId = UserId, ConcertId = concertId };
            var ticketId = await Mediator.Send(command);
            return Ok(ticketId);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid ticketId)
        {
            var command = new DeleteTicketCommand() { Id = ticketId };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
