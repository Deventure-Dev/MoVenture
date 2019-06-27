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

            CreateMap<Playlist, Moventure.BusinessLogic.Models.DisplayPlaylist>()
                .AfterMap((source, destination) =>
                {
                    if(source.MovieList == null)
                    {
                        return;
                    }
                    foreach (var assignment in source.MovieList)
                    {
                        if (assignment.Movie == null)
                        {
                            continue;
                        }
                        destination.Movies.Add(assignment.Movie.Title);
                    }
                });
        }
    }
}
