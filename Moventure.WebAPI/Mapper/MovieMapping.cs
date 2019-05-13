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
            CreateMap<Movies, Movie>();
            CreateMap<Movie, Movies>();
        }
    }
}
