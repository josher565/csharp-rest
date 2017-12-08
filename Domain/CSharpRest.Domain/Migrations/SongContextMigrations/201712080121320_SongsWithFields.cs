namespace CSharpRest.Domain.Migrations.SongContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongsWithFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "track", c => c.Int(nullable: false));
            AddColumn("dbo.Songs", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "name");
            DropColumn("dbo.Songs", "track");
        }
    }
}
