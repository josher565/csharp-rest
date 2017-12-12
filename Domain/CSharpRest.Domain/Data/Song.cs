using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.Data
{
    public class Song : BaseModel
    {
        public Song() : this(new Album()) { }

        public Song(Album album)
        {
            Album = album;
        }

        public int track { get; set; }
        public string name { get; set; }

        public virtual Album Album {get; set;}
    }
}
