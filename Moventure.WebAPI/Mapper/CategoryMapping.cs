using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moventure.BusinessLogic.Mapper
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryModel>()
                .BeforeMap((source, destination) =>
                {
                })
                //.ForMember(m => m.Id, opt => opt.MapFrom(m => m.Id))
                //.ForMember(m => m.Name, opt => opt.MapFrom(m => m.Name))
                //.ForMember(m => m.SavedAt, opt => opt.MapFrom(m => m.SavedAt))
                .ForMember(m => m.SavedBy, opt => opt.Ignore())
                .AfterMap((source, destination) =>
                {
                    destination.SavedBy = "Marcel Pavel";
                });

            CreateMap<CategoryModel, Category>();
        }
    }
}
