using AutoMapper;
using MoCodeFirst.Models;
using MoCodeFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoCodeFirst.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryView>();
            CreateMap<CategoryView, Category>();
        }
    }
}
