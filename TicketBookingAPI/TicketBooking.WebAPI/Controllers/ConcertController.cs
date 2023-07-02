using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using TicketBooking.Application.Features.Concerts.Commands.CreateConcert;
using TicketBooking.Application.Features.Concerts.Queries.GetConcertList;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ConcertController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ConcertListVm>> GetAll()
        {
            var query = new GetConcertListQuery();

            var vm = await Mediator.Send(query);

            return vm;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] JsonObject _jsonObj)
        {
            var command = new CreateConcertCommand() { jsonObj = _jsonObj };
            
            var concertId = await Mediator.Send(command);
            return Ok(concertId);
        }
    }
}
