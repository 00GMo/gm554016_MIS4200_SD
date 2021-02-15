namespace gm554016.Migrations.GameLibraryContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<gm554016.DAL.GameLibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\GameLibraryContext";
            ContextKey = "gm554016.DAL.GameLibraryContext";
        }

        protected override void Seed(gm554016.DAL.GameLibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
