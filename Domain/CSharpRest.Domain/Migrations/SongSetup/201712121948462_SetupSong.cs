namespace CSharpRest.Domain.Migrations.SongSetup
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupSong : DbMigration
    {
        public override void Up()
        {
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
            
            //CreateTable(
            //    "dbo.Artists",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            name = c.String(),
            //            Created = c.DateTime(nullable: false),
            //            LastModified = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        track = c.Int(nullable: false),
                        name = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        Album_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            //DropIndex("dbo.Songs", new[] { "Album_Id" });
            //DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropTable("dbo.Songs");
            //DropTable("dbo.Artists");
            //DropTable("dbo.Albums");
        }
    }
}
