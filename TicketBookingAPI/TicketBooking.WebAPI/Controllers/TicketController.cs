using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketBooking.Application.Features.Tickets.Commands.CreateTicket;
using TicketBooking.Application.Features.Tickets.Commands.DeleteTicket;
using TicketBooking.Application.Features.Tickets.Queries.GetTicket;
using TicketBooking.Application.Features.Tickets.Queries.GetTicketList;
using TicketBooking.Application.Features.Concerts.Queries.GetConcert;
using TicketBooking.Email;
using TicketBooking.Application.Features.Tickets.Commands.ConfirmTicket;
using TicketBooking.Application.Features.Tickets.Commands.ApprovePaymentTicket;

namespace TicketBooking.WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [Authorize]
    public class TicketController : BaseController
    {
        private readonly IEmailSender _emailSender;

        public TicketController(IEmailSender emailSender) 
            => _emailSender = emailSender;

        [HttpGet]
        public async Task<ActionResult<TicketListVm>> GetAll()
        {
            var query = new GetTicketListQuery() { UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /*[HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<TicketVm>> Get(Guid concertId)
        {
            var query = new GetTicketQuery() { UserId = UserId, ConcertId = concertId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }*/

        /*[HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] Guid concertId)
        {
            var command = new CreateTicketCommand() { UserId = UserId, ConcertId = concertId };
            var ticketId = await Mediator.Send(command);

            // email confirmation
            *//*var query = new GetConcertQuery() { Id = concertId };
            var concert = await Mediator.Send(query);

            var email = User.FindFirstValue(ClaimTypes.Email);
            var message = new Message(new[] { email },
                $"Booking ticket for \"{concert.ConcertName}\"",
                $"Confirm the booking of the ticket for the \"{concert.ConcertName}\" concert at {concert.DateTime.ToString("dddd, dd MMMM yyyy HH:mm")}.",
                ticketId);
            await _emailSender.SendConfirmationAsync(message);*//*

            return Ok(ticketId);
        }*/

        [AllowAnonymous]
        [HttpPost]
        [Route("confirm/{ticketId}")]
        public async Task<ActionResult> ConfirmTicket(Guid ticketId)
        {
            var command = new ConfirmTicketCommand() { Id = ticketId };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        [Route("approve-payment")]
        public async Task<ActionResult> ApprovePayment([FromBody] Guid id)
        {
            var command = new ApprovePaidTicketCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTicketCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
