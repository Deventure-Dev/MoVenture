using AutoMapper;
//using Moventure.BusinessLogic.Models;
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
            CreateMap<Moventure.BusinessLogic.Models.Movie, Movie>();
            CreateMap<Movie, Moventure.BusinessLogic.Models.Movie> ();
        }
    }
}
