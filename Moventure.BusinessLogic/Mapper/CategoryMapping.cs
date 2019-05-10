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
            CreateMap<Categories, CategoryModel>()
                .ForMember(m => m.SavedBy, opt => opt.Ignore());

            CreateMap<CategoryModel, Categories>();
        }
    }
}
