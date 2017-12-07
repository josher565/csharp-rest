using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.DataAccess
{
    public class SongAccess : DbContext
    {
        public SongAccess() : base("MusicDb") {}

        public virtual DbSet<Data.Song> Songs { get; set; }
    }
}
