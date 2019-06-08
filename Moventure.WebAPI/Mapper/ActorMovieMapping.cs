using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventure.BusinessLogic.Mapper
{
    public class ActorMovieMapping : Profile
    {
        public ActorMovieMapping()
        {
            CreateMap<MovieActorAssignment, ActorsMovieAssignmentModel>();
            CreateMap<ActorsMovieAssignmentModel, MovieActorAssignment>();
        }
    }
}
