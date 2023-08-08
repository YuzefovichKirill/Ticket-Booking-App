using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using TicketBooking.Application.Features.Concerts.Commands.CreateConcert;
using TicketBooking.Application.Features.Concerts.Commands.DeleteConcert;
using TicketBooking.Application.Features.Concerts.Commands.UpdateConcert;
using TicketBooking.Application.Features.Concerts.Queries.GetConcert;
using TicketBooking.Application.Features.Concerts.Queries.GetConcertList;
using TicketBooking.Domain;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    public class ConcertController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ConcertListVm>> GetAll(string containsInName = "", string concertType = "")
        {
            var query = new GetConcertListQuery() { ContainsInName = containsInName, ConcertType = concertType };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Concert>> Get(Guid id)
        {
            var query = new GetConcertQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Create([FromBody] JsonObject jsonObj)
        {
            var command = new CreateConcertCommand() { JsonObj = jsonObj };
            var concertId = await Mediator.Send(command);
            return Ok(concertId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update([FromBody] JsonObject jsonObj)
        {
            var command = new UpdateConcertCommand() { JsonObj = jsonObj };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteConcertCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
