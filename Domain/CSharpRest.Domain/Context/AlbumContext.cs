using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;

namespace CSharpRest.Domain.Contexts
{
    public class AlbumContext : DbContext
    {
        public AlbumContext() : base("MusicDb") {
              
        }

        public virtual DbSet<Data.Album> Albums { get; set; }

    }
}
