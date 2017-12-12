namespace CSharpRest.Domain.Migrations.ArtistSetup
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupArtist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            



            //CreateTable(
            //    "dbo.Albums",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            name = c.String(),
            //            yearReleased = c.Int(nullable: false),
            //            Created = c.DateTime(nullable: false),
            //            LastModified = c.DateTime(nullable: false),
            //            Artist_Id = c.Long(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Artists", t => t.Artist_Id)
            //    .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            //DropIndex("dbo.Albums", new[] { "Artist_Id" });
            //DropTable("dbo.Albums");
            DropTable("dbo.Artists");
        }
    }
}
