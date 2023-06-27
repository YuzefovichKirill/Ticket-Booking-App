using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(TicketBookingDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //...
        }
    }
}
