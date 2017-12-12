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

        public Data.Album Create(Album entity, DateTime createDate)
        {
            using (Context)
            {
                entity.Created = createDate;
                Context.Albums.Add(entity);
                Context.SaveChanges();
            }
            return entity;
        }

        public void Delete(Album entity)
        {
            using (Context)
            {
                Context.SetObjectState(entity, EntityState.Deleted);
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

        public Data.Album Update(Album entity, DateTime updateDate)
        {
            Album rAlbum = null;
            using (Context)
            {
                entity.LastModified = updateDate;
                rAlbum = Context.Albums.Attach(entity);
                Context.SetObjectState(entity, EntityState.Modified);
                Context.SaveChanges();
            }
            return rAlbum;
        }
    }
}
