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
                        DisplayMovie movieToAdd = new DisplayMovie()
                        {
                            Id = assignment.Movie.Id,
                            Title = assignment.Movie.Title,
                            Rating = assignment.Movie.Rating,
                            PictureUrl = assignment.Movie.PictureUrl,
                            CategoryName = (assignment.Movie.CategoryId).ToString(),
                            Description = assignment.Movie.Description,
                            Tags = new List<string> { },
                            Actors = new List<string> { }
                        };
                        destination.Movies.Add(movieToAdd);
                    }
                });
        }
    }
}
