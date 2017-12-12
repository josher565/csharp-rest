using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.Data
{
    public class Artist : BaseModel
    {
        public Artist() : this(new HashSet<Album>()) { }

        public Artist(HashSet<Album> albums)
        {
            Albums = albums;
        }

        public string name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
