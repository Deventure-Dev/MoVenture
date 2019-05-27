using AutoMapper;
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
            CreateMap< Moventure.BusinessLogic.Models.Playlist, Playlist >();
            CreateMap<Playlist, Moventure.BusinessLogic.Models.Playlist> ();
        }
    }
}
