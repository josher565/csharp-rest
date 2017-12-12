using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;
using System.Data.Entity;

namespace CSharpRest.Domain.Access
{
    public class SongAccess : ICrud<Data.Song>
    {
        public SongAccess(Contexts.SongContext context)
        {
            Context = context;
        }

        public Contexts.SongContext Context { get; set; }

        public Song Create(Song entity, DateTime createDate)
        {
            Song rSong = null;
            using (Context)
            {
                rSong = Context.Songs.Add(entity);
                Context.SaveChanges();
            }
            return rSong;
        }

        public void Delete(Song entity)
        {
            using (Context)
            {
                Context.SetObjectState(entity, System.Data.Entity.EntityState.Deleted);
                Context.SaveChanges();
            }
        }

        public Song Read(int id)
        {
            Song rSong = null;
            using (Context)
            {
                rSong = Context.Songs.Find(id);
            }
            return rSong;
        }

        public Song Update(Song entity, DateTime createDate)
        {
            Song rSong = null;
            using (Context)
            {
                rSong = Context.Songs.Attach(entity);
                Context.SetObjectState(entity, System.Data.Entity.EntityState.Modified);
                Context.SaveChanges();
            }
            return rSong;
        }
    }
}
