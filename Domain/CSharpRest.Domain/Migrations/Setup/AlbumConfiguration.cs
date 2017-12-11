namespace CSharpRest.Domain.Migrations.Setup
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AlbumConfiguration : DbMigrationsConfiguration<CSharpRest.Domain.Contexts.AlbumContext>
    {
        public AlbumConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Setup";
        }

        protected override void Seed(CSharpRest.Domain.Contexts.AlbumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
