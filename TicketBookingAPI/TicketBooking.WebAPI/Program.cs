using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using TicketBooking.Persistance;
using TicketBooking.Persistence;

namespace TicketBooking.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;

            ConfigurationManager config = builder.Configuration;
            services.AddPersistence(config);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            //services.AddSwaggerGen();

            // Configure
            var app = builder.Build();

            /*using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<TicketBookingDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return;
                }
            }*/

            //app.UseSwagger();
            //app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket booking v1"));

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            //app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}