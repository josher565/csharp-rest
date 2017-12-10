using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;
using System.Data.Entity;

namespace CSharpRest.Domain.Access
{
    public class AlbumAccess : ICrud<Data.Album>
    {
        public AlbumAccess(Contexts.AlbumContext context)
        {
            Context = context;
        }

        public Contexts.AlbumContext Context { get; set; }

        public Data.Album Create(Album entity)
        {
            Data.Album rAlbum = null;
            using (var ctx = new Contexts.AlbumContext())
            {
                rAlbum = ctx.Albums.Add(entity);
                ctx.SaveChanges();
            }
            return rAlbum;
        }

        public void Delete(Album entity)
        {
            using (var ctx = new Contexts.AlbumContext())
            {
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public Album Read(int id)
        {
            Album rAlbum = null;
            using(var ctx = new Contexts.AlbumContext())
            {
                rAlbum = ctx.Albums.Find(id);
            }
            return rAlbum;
        }

        public Data.Album Update(Album entity)
        {
            Album rAlbum = null;
            using (var ctx = new Contexts.AlbumContext())
            {
                rAlbum = ctx.Albums.Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return rAlbum;
        }
    }
}
