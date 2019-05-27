using AutoMapper;
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
            CreateMap< Moventure.BusinessLogic.Models.User, User >();
            CreateMap<User, Moventure.BusinessLogic.Models.User> ();
        }
    }
}
