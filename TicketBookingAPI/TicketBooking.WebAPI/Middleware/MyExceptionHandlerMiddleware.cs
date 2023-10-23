using System.Net;
using System.Text.Json;
using TicketBooking.Application.Exceptions;

namespace TicketBooking.WebAPI.Middleware
{
    public class MyExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public MyExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;
    
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
    
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = exception.Message });
            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;

                case NotEnoughTicketsException:
                    code = HttpStatusCode.Conflict;
                    break;
                case ArgumentException:
                case AlreadyUsedException:
                case System.ComponentModel.DataAnnotations.ValidationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case FluentValidation.ValidationException ex:
                    code = HttpStatusCode.BadRequest;
                    result = String.Join("\n", ex.Errors.ToList());
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
