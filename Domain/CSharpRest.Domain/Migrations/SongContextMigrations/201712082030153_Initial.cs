namespace CSharpRest.Domain.Migrations.SongContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        track = c.Int(nullable: false),
                        name = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        SongAlbum_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.SongAlbum_Id)
                .Index(t => t.SongAlbum_Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        yearReleased = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        AlbumArtist_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.AlbumArtist_Id)
                .Index(t => t.AlbumArtist_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "SongAlbum_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "AlbumArtist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "AlbumArtist_Id" });
            DropIndex("dbo.Songs", new[] { "SongAlbum_Id" });
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
            DropTable("dbo.Songs");
        }
    }
}
