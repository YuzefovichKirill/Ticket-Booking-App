using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data
{
    public class DbInitializer
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
