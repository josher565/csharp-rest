﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.Data
{
    public class Album : BaseModel
    {
        public Album() : this(new Artist()) { }

        public Album(Artist artist)
        {
            Artist = artist;
        }

        public string name { get; set; }

        public int yearReleased { get; set; }

        public virtual Artist Artist {get; set;}
   
    }
}
