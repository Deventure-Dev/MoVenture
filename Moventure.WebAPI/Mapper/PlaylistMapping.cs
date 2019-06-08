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
            CreateMap< Moventure.BusinessLogic.Models.PlaylistModel, Playlist >();
            CreateMap<Playlist, Moventure.BusinessLogic.Models.PlaylistModel> ();
        }
    }
}
