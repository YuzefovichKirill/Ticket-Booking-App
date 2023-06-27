using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Application.Interfaces;
using TicketBooking.Persistance;

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
                provider.GetService<ITicketBookingDbContext>());
            return services;
        }

    }
}
