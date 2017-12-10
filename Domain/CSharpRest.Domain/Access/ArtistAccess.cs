using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;
using System.Data.Entity;

namespace CSharpRest.Domain.Access
{
    public class ArtistAccess : ICrud<Data.Artist>
    {
        public ArtistAccess(Contexts.ArtistContext context)
        {
            Context = context;
        }

        public Contexts.ArtistContext Context { get; set; }

        public Data.Artist Create(Artist entity)
        {
            Artist rArtist = null;
            using (var ctx = new Contexts.ArtistContext())
            {
                rArtist = ctx.Artists.Add(entity);
                ctx.SaveChanges();
            }
            return rArtist;
        }

        public void Delete(Artist entity)
        {
            using (var ctx = new Contexts.ArtistContext())
            {
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public Artist Read(int id)
        {
            Artist rArtist = null;
            using (var ctx = new Contexts.ArtistContext())
            {
                rArtist = ctx.Artists.Find(id);
            }
            return rArtist;
        }

        public Data.Artist Update(Artist entity)
        {
            Artist rArtist = null;
            using (var ctx = new Contexts.ArtistContext())
            {
                rArtist = ctx.Artists.Attach(entity);
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return rArtist;
        }
    }
}
