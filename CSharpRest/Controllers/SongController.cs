﻿using CSharpRest.Domain.Access;
using CSharpRest.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSharpRest.Controllers
{
    public class SongController : ApiController
    {
        public SongController() : this(new SongAccess(new Domain.Contexts.SongContext())) { }

        public SongController(SongAccess access)
        {
            SongGopher = access;
        }

        public SongAccess SongGopher { get; set; }

        // GET: api/Song/5
        public Song Get(int id)
        {
            return SongGopher.Read(id);
        }

        // POST: api/Song
        public void Post(Song song)
        {
            SongGopher.Create(song, DateTime.Now);
        }

        // PUT: api/Song/5
        public void Put(Song song)
        {
            SongGopher.Update(song, DateTime.Now);
        }

        // DELETE: api/Song/5
        public void Delete(Song song)
        {
            SongGopher.Delete(song);
        }
    }
}
