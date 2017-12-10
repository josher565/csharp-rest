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
            using (Context)
            {
                Context.Albums.Add(entity);
                Context.SaveChanges();
            }
            return entity;
        }

        public void Delete(Album entity)
        {
            using (Context)
            {
                Context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public Album Read(int id)
        {
            Album rAlbum = null;
            using(Context)
            {
                rAlbum = Context.Albums.Find(id);
            }
            return rAlbum;
        }

        public Data.Album Update(Album entity)
        {
            Album rAlbum = null;
            using (Context)
            {
                rAlbum = Context.Albums.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
            }
            return rAlbum;
        }
    }
}
