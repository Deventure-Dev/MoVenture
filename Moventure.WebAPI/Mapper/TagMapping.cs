using AutoMapper;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap< Moventure.BusinessLogic.Models.Tag, Tag >();
            CreateMap<Tag, Moventure.BusinessLogic.Models.Tag>();
        }
    }
}
