namespace CSharpRest.Domain.Migrations.DbMigration
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CSharpRest.Domain.Contexts.AlbumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DbMigration";
        }

        protected override void Seed(CSharpRest.Domain.Contexts.AlbumContext context)
        {

        }
    }
}
