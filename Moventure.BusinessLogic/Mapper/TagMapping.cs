using AutoMapper;
using Moventure.BusinessLogic.Models;
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
            CreateMap<Tags, Tag>();
            CreateMap<Tag, Tags>();
        }
    }
}
