namespace CSharpRest.Domain.Migrations.ArtistSetup
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CSharpRest.Domain.Contexts.ArtistContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ArtistSetup";
            ContextKey = "ArtistModel";
        }

        protected override void Seed(CSharpRest.Domain.Contexts.ArtistContext context)
        {
            //System.Data.SqlClient.SqlException: Cannot insert the value NULL into column 'Created', table 'MusicDb.dbo.Artists'; column does not allow nulls. INSERT fails.

            //var now = DateTime.Now;
            //context.Artists.Add(new Data.Artist() { name = "Muse", Created = now, LastModified = now });
            //context.Artists.Add(new Data.Artist() { name = "Duran Duran", Created = now, LastModified = now });
            //context.Artists.Add(new Data.Artist() { name = "Van Halen", Created = now, LastModified = now });
            //base.Seed(context);
        }
    }
}
