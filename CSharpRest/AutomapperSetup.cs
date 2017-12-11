using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpRest
{
    public static class AutomapperSetup
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Domain.Data.Album, Models.AlbumModel>();
                cfg.CreateMap<Domain.Data.Artist, Models.ArtistModel>();
                cfg.CreateMap<Domain.Data.Song, Models.SongModel>();

                cfg.CreateMap<Models.AlbumModel, Domain.Data.Album>();
                cfg.CreateMap<Models.ArtistModel, Domain.Data.Artist>();
                cfg.CreateMap<Models.SongModel, Domain.Data.Song>();
            });
        }
    }
}