namespace CSharpRest.Domain.Migrations.DbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SqlLoad : DbMigration
    {
        public override void Up()
        {
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

            Sql(@"SET IDENTITY_INSERT songs ON");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(1, 1, 1, 'Dead Inside', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(2, 1, 2, 'Drill Sargeant', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(3, 1, 3, 'Psycho', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(4, 1, 4, 'Mercy', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(5, 1, 5, 'Reapers', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(6, 1, 6, 'The Handler', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(7, 1, 7, 'JFK', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(8, 1, 8, 'Defector', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(9, 1, 9, 'Revolt', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(10, 1, 10, 'Aftermath', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(11, 1, 11, 'The Globalist', getdate(), getdate())");
            Sql(@"insert into songs(id, songalbum_id, track, name, created, lastmodified) values(12, 1, 12, 'Drones', getdate(), getdate())");
            Sql(@"SET IDENTITY_INSERT songs OFF");
        }
        
        public override void Down()
        {
        }
    }
}
