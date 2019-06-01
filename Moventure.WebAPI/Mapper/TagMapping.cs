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
            CreateMap<Tag, TagModel>()
                .BeforeMap((source, destination) =>
                {
                })
                //.ForMember(m => m.Id, opt => opt.MapFrom(m => m.Id))
                //.ForMember(m => m.Name, opt => opt.MapFrom(m => m.Name))
                //.ForMember(m => m.SavedAt, opt => opt.MapFrom(m => m.SavedAt))
                .ForMember(tag => tag.SavedBy, opt => opt.Ignore())
                .AfterMap((source, destination) =>
                {
                    destination.SavedBy = "Silviu";
                });
            CreateMap<TagModel, Tag>();

        }
    }
}
