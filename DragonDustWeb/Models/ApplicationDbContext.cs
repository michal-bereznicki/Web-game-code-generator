using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DragonDustWeb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCode> GameCodes { get; set; }

        public ApplicationDbContext()
        {
        }
    }
}