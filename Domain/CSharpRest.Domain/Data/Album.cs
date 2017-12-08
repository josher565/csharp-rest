using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.Data
{
    public class Album : BaseModel
    {
        public string name { get; set; }
        public int yearReleased { get; set; }

        public virtual Artist AlbumArtist { get; set; }
        public virtual ICollection<Song> AlbumSong { get; set; }
    }
}
