using CSharpRest.Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSharpRest.Controllers
{
    public class AlbumController : ApiController
    {
        public AlbumController() : this(new AlbumContext()) { }

        public AlbumController(AlbumContext albumAccess) {
            AlbumGopher = albumAccess;
        }

        public AlbumContext AlbumGopher { get; set; }
 
        // GET: api/Album/5
        public string Get(int id)
        {
           // AlbumGopher.Albums
            return "value";
        }

        // POST: api/Album
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Album/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Album/5
        public void Delete(int id)
        {
        }
    }
}
