using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    class PlaylistMapping : Profile
    {
        public PlaylistMapping()
        {
            CreateMap<Playlists, Playlist>();
            CreateMap<Playlist, Playlists>();
        }
    }
}
