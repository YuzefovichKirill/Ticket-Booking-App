namespace TicketBooking.WebAPI.Middleware
{
    public static class MyExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyExceptionHandler(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<MyExceptionHandlerMiddleware>();
        }

    }
}
