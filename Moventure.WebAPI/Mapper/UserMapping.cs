using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<Users, User>();
            CreateMap<User, Users>();
        }
    }
}
