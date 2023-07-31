using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Application.Interfaces;

namespace TicketBooking.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["TicketBookingConnection"];

            services.AddDbContext<TicketBookingDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ITicketBookingDbContext>(provider =>
                provider.GetService<TicketBookingDbContext>());
            return services;
        }

    }
}
