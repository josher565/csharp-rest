namespace CSharpRest.Domain.Migrations.Setup
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupAlbumMigration : DbMigration
    {
        public override void Up()
        {
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

            Sql(@"SET IDENTITY_INSERT artists ON");
            Sql(@"insert into artists(id, name, created, lastmodified) values(1, 'Muse', getdate(), getdate())");
            Sql(@"insert into artists(id, name, created, lastmodified) values(2, 'Duran Duran', getdate(), getdate())");
            Sql(@"insert into artists(id, name, created, lastmodified) values(3, 'Van Halen', getdate(), getdate())");
            Sql(@"SET IDENTITY_INSERT artists OFF");

            Sql(@"SET IDENTITY_INSERT albums ON");
            Sql(@"insert into albums(id, name, yearreleased, AlbumArtist_Id, created, lastmodified) values(1, 'Drones', 2015, 1, getdate(), getdate())");
            Sql(@"insert into albums(id, name, yearreleased, AlbumArtist_Id, created, lastmodified) values(2, 'Origin of Symmetry', 2001, 1, getdate(), getdate())");
            Sql(@"insert into albums(id, name, yearreleased, AlbumArtist_Id, created, lastmodified) values(3, 'Rio', 1982, 3, getdate(), getdate())");
            Sql(@"insert into albums(id, name, yearreleased, AlbumArtist_Id, created, lastmodified) values(4, '1984', 1984, 3, getdate(), getdate())");
            Sql(@"SET IDENTITY_INSERT albums OFF");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "AlbumArtist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "AlbumArtist_Id" });
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
