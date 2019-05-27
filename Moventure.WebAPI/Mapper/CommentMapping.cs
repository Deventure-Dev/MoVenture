using AutoMapper;
//using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Moventure.BusinessLogic.Models.Comment, Comment>();
            CreateMap<Comment, Moventure.BusinessLogic.Models.Comment>();
        }
    }
}
