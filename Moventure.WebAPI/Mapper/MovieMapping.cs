using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
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
                .AfterMap((source, destination) => {
                    destination.CreatedBy = "Silviu";
                });
            CreateMap<MovieModel, Movie> ();
        }
    }
}
