using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TicketBooking.Application;
using TicketBooking.Email;
using TicketBooking.Persistence;
using TicketBooking.WebAPI.Middleware;

namespace TicketBooking.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IServiceCollection services = builder.Services;

            ConfigurationManager configuration = builder.Configuration;
            services.AddApplication();
            services.AddPersistence(configuration);
            services.AddControllers();
             
            /*var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            emailConfig.Password = configuration["Gmail:Password"];
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();*/

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                return settings;
            };

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddSwaggerGen();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:7181/";
                    options.Audience = "TicketBookingAPI";
                    options.RequireHttpsMetadata = false;
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:7181/";
                    options.ClientId = "TicketBookingAPI";
                    options.ResponseType = "id_token token";
                    options.GetClaimsFromUserInfoEndpoint = true;
                });
            services.AddAuthorization();

            // Configure
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
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
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket booking v1"));
            }

            app.UseMyExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.Run();
        }
    }
}