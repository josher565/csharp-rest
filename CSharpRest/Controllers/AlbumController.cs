using CSharpRest.Domain.Access;
using CSharpRest.Domain.Contexts;
using CSharpRest.Domain.Data;
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
        public AlbumController() : this(new AlbumAccess(new AlbumContext())) { }

        public AlbumController(AlbumAccess albumAccess) {
            AlbumGopher = albumAccess;
        }

        public AlbumAccess AlbumGopher { get; set; }
 
       
        public Album Get(int id)
        {
            return AlbumGopher.Read(id);
        }

      
        public void Post(Album album)
        {
            AlbumGopher.Create(album);
        }

    
        public void Put(Album album)
        {
            AlbumGopher.Update(album);
        }

   
        public void Delete(Album album)
        {
            AlbumGopher.Delete(album);
        }
    }
}
