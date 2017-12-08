using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpRest.Domain.Data
{
    public class Song : BaseModel
    {
        public int track { get; set; }
        public string name { get; set; }
    }
}
