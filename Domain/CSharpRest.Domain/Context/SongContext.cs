using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;
using CSharpRest.Domain.Access;

namespace CSharpRest.Domain.Contexts
{
    public class SongContext : DbContext
    {
        public SongContext() : base("MusicDb") {}

        public virtual DbSet<Data.Song> Songs { get; set; }

        public virtual void SetObjectState(Data.Song entity, EntityState state)
        {
            Entry(entity).State = state;
        }
    }
}
