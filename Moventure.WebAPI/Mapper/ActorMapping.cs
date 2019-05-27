using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    class ActorMapping : Profile
    {
        public ActorMapping()
        {
            CreateMap<Actor, ActorModel>();
            CreateMap<ActorModel, Actor>();
        }
    }
}
