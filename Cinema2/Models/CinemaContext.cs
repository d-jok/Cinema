using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema2.Models
{
    public class CinemaContext : DbContext
    {
        public DbSet<Session> Session;
        public DbSet<Tickets> Tickets;

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
