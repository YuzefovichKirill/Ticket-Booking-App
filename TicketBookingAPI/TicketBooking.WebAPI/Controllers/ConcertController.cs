using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Application.Features.Concerts.Commands.CreateClassicalConcert;
using TicketBooking.Application.Features.Concerts.Commands.CreateOpenAir;
using TicketBooking.Application.Features.Concerts.Commands.CreateParty;
using TicketBooking.Application.Features.Concerts.Commands.DeleteConcert;
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
        public async Task<ActionResult<ConcertListVm>> GetAll(string? containsInName = "", string? concertType = "")
        {
            var query = new GetConcertListQuery() { ContainsInName = containsInName, ConcertType = concertType };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Concert>> Get(Guid id)
        {
            var query = new GetConcertQuery() { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("Classical-concert")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> CreateClassicalConcert([FromBody] CreateClassicalConcertCommand command)
        {
            var concertId = await Mediator.Send(command);
            return Ok(concertId);
        }

        [HttpPost("open-air")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> CreateOpenAir([FromBody] CreateOpenAirCommand command)
        {
            var concertId = await Mediator.Send(command);
            return Ok(concertId);
        }

        [HttpPost("party")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> CreateParty([FromBody] CreatePartyCommand command)
        {
            var concertId = await Mediator.Send(command);
            return Ok(concertId);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteConcertCommand() { Id = id };
            var concertId = await Mediator.Send(command);
            return Ok(concertId);
        }
    }
}
