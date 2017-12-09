using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpRest.Domain.Data;

namespace CSharpRest.Domain.Access
{
    public class AlbumAccess : ICrud<Data.Album>
    {

        public void Create(Album entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Album entity)
        {
            throw new NotImplementedException();
        }

        public Album Read(int id)
        {
            Album rAlbum = null;
            using(var ctx = new Contexts.AlbumContext())
            {
                rAlbum = ctx.Albums.Find(id);
            }
            return rAlbum;
        }

        public void Update(Album entity)
        {
            throw new NotImplementedException();
        }
    }
}
