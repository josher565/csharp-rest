using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CSharpRest.Models
{
    [DataContract]
    public class SongModel
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public string name { get; set; }

        public int yearReleased { get; set; }

        public virtual long ArtistId { get; set; }

        public long AlbumId { get; set; }
    }
}