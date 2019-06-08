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
            CreateMap<Moventure.BusinessLogic.Models.CommentModel, Comment>()
                            .BeforeMap((source, destination) =>
                             {
                             })
                .ForMember(m => m.SavedAtMovie, opt => opt.Ignore())
                .ForMember(m => m.SavedByNavigation, opt => opt.Ignore());

            CreateMap<Comment, Moventure.BusinessLogic.Models.CommentModel>();
        }
    }
}
