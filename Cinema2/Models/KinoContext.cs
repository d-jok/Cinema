using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema2.Models
{
    public class KinoContext : DbContext
    {
        public DbSet<BuyTicket> BuyTickets { get; set; }
        public DbSet<Place> Place { get; set; }

        public KinoContext(DbContextOptions<KinoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
