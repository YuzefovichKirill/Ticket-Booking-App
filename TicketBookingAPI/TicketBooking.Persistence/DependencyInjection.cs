using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketBooking.Application.Interfaces;
using TicketBooking.Domain.Interfaces;
using TicketBooking.Persistence.Repositories;

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

            services.AddScoped<IUnitOfWork>(provider =>
                provider.GetService<TicketBookingDbContext>());

            services.AddScoped<IConcertRepository, ConcertRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            services.AddScoped<IUsedCouponRepository, UsedCouponRepository>();

            return services;
        }

    }
}
