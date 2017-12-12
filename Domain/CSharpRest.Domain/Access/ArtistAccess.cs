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

        public Data.Artist Create(Artist entity, DateTime createDate)
        {
            Artist rArtist = null;
            using (Context)
            {
                rArtist = Context.Artists.Add(entity);
                Context.SaveChanges();
            }
            return rArtist;
        }

        public void Delete(Artist entity)
        {
            using (Context)
            {
                Context.SetObjectState(entity, EntityState.Deleted);
                Context.SaveChanges();
            }
        }

        public Artist Read(int id)
        {
            Artist rArtist = null;
            using (Context)
            {
                rArtist = Context.Artists.Find(id);
            }
            return rArtist;
        }

        public Data.Artist Update(Artist entity, DateTime updateDate)
        {
            Artist rArtist = null;
            using (var ctx = new Contexts.ArtistContext())
            {
                rArtist = ctx.Artists.Attach(entity);
                Context.SetObjectState(entity, EntityState.Modified);
                ctx.SaveChanges();
            }
            return rArtist;
        }
    }
}
