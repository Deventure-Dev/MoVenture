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

                }).ForMember(m => m.SavedBy, opt => opt.Ignore())
                .AfterMap((source, destination) =>
                {
                    //destination.SavedBy = getFromDb(source.SavedBy)
                });

            CreateMap<CategoryModel, Category>();
        }
    }
}
