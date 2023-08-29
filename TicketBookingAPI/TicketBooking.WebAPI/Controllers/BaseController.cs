using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TicketBooking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public Guid UserId => User.Identity.IsAuthenticated
            ? Guid.Parse(User.FindFirstValue("sub"))
            //? Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)
            : Guid.Empty;
    }
}
