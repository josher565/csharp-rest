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
        public void Create(Song entity)
        {
            using (var ctx = new Contexts.SongContext())
            {
                ctx.Songs.Add(entity);
                ctx.SaveChanges();
            }
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

        public void Update(Song entity)
        {
            using (var ctx = new Contexts.SongContext())
            {
                ctx.Songs.Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
