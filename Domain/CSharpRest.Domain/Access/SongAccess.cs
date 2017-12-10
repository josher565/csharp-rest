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

        public Song Create(Song entity)
        {
            Song rSong = null;
            using (var ctx = new Contexts.SongContext())
            {
                rSong = ctx.Songs.Add(entity);
                ctx.SaveChanges();
            }
            return rSong;
        }

        public void Delete(Song entity)
        {
            using (var ctx = new Contexts.SongContext())
            {
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public Song Read(int id)
        {
            Song rSong = null;
            using (var ctx = new Contexts.SongContext())
            {
                rSong = ctx.Songs.Find(id);
            }
            return rSong;
        }

        public Song Update(Song entity)
        {
            Song rSong = null;
            using (var ctx = new Contexts.SongContext())
            {
                rSong = ctx.Songs.Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return rSong;
        }
    }
}
