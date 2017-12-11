namespace CSharpRest.Domain.Migrations.Setup
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SongConfiguration : DbMigrationsConfiguration<CSharpRest.Domain.Contexts.SongContext>
    {
        public SongConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Setup";
        }

        protected override void Seed(CSharpRest.Domain.Contexts.SongContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
