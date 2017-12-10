using CSharpRest.Domain.Access;
using CSharpRest.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSharpRest.Controllers
{
    public class ArtistController : ApiController
    {
        public ArtistController() : this(new ArtistAccess(new Domain.Contexts.ArtistContext())) { }

        public ArtistController(ArtistAccess access)
        {
            ArtistGopher = access;
        }

        public ArtistAccess ArtistGopher { get; set; }

        public Artist Get(int id)
        {
            return ArtistGopher.Read(id);
        }

        public void Post(Artist artist)
        {
            ArtistGopher.Create(artist);
        }

        public void Put(Artist artist)
        {
            ArtistGopher.Update(artist);
        }

        public void Delete(Artist artist)
        {
            ArtistGopher.Delete(artist);
        }
    }
}
