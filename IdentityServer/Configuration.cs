using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", new[] { "role" })
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("TicketBookingAPI", "My ticket booking API",
                    new [] { JwtClaimTypes.Email, JwtClaimTypes.Role, JwtClaimTypes.Name })
                {
                    Scopes = { "TicketBookingAPI" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("TicketBookingAPI", "My ticket booking API")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "react-web-app",
                    ClientName = "React client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =
                    {
                        "http://localhost:3000/signin-callback"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:3000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:3000/signout-callback"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "TicketBookingAPI"
                    }
                }
            };

        public static async Task CreateRoles(IServiceCollection serviceCollection)
        {
            using(ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await RoleManager.RoleExistsAsync("Admin"))
                {
                    await RoleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (!await RoleManager.RoleExistsAsync("User"))
                {
                    await RoleManager.CreateAsync(new IdentityRole("User"));
                }
            }
        }
    }
}
