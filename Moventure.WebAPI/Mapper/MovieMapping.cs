using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    class MovieMapping : Profile
    {
        public MovieMapping()
        {
            CreateMap<Movie, MovieModel>()
                .BeforeMap((source, destionation) => { })
                .ForMember(movie => movie.CreatedBy, opt => opt.Ignore())
                .AfterMap((source, destination) =>
                {
                    destination.CreatedBy = "Silviu";
                });
            CreateMap<MovieModel, Movie>();

            CreateMap<Movie, DisplayMovie>()
                .ForMember(m => m.Tags, opt => opt.Ignore())
                .AfterMap((source, destination) =>
                {
                    //destination.Tags = source.TagList.Select(assignment => assignment.Tag?.Name).ToList();
                    if (source.TagList == null || source.TagList.Count == 0)
                    {
                        return;
                    }

                    foreach (var assignment in source.TagList)
                    {
                        if (assignment.Tag == null)
                        {
                            continue;
                        }
                        destination.Tags.Add(assignment.Tag.Name);
                    }
                });
        }
    }
}
