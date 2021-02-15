using gm554016.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gm554016.DAL
{
    public class GameLibraryContext : DbContext
    {
        public GameLibraryContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Developer> developer { get; set; }

        public DbSet<Consoles> consoles { get; set; }

        public DbSet<Game> game { get; set; }

        public DbSet<Publisher> publisher { get; set; }

        public DbSet<Owner> owner { get; set; }
    }
}