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
    public class SongContext : DbContext, ICrud<Data.Song>
    {
        public SongContext() : base("MusicDb") {}

        public virtual DbSet<Data.Song> Songs { get; set; }

        public void Create(Song entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Song entity)
        {
            throw new NotImplementedException();
        }

        public Song Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Song entity)
        {
            throw new NotImplementedException();
        }
    }
}
