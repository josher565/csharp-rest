using AutoMapper;
using CSharpRest.Domain.Access;
using CSharpRest.Domain.Contexts;
using CSharpRest.Domain.Data;
using CSharpRest.Models;
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
 
       
        public AlbumModel Get(int id)
        {
            var r = AlbumGopher.Read(id);
            var model = Mapper.Map<AlbumModel>(r);
            return model;
        }

      
        public void Post(AlbumModel album)
        {
            var db = Mapper.Map<Album>(album);
            AlbumGopher.Create(db);
        }

    
        public void Put(AlbumModel album)
        {
            var db = Mapper.Map<Album>(album);
            AlbumGopher.Update(db);
        }

   
        public void Delete(AlbumModel album)
        {
            var db = Mapper.Map<Album>(album);
            AlbumGopher.Delete(db);
        }
    }
}
