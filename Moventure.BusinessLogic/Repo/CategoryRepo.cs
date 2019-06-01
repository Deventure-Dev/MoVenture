using AutoMapper;
using Moventure.BusinessLogic.Models;
using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class CategoryRepo : BaseSinglePkRepository<Category>
    {
        private readonly IMapper mMapper;
        public CategoryRepo(IMapper mapper)
        {
            mMapper = mapper;
        }

        /*
         *         protected override AspNetRole FetchFromDb(AspNetRole entity, IList<string> navigationProperties = null)
        {
            return GetSingle(aspNetRole => aspNetRole.Id == entity.Id, navigationProperties);
        }

        protected override async Task<AspNetRole> FetchFromDbAsync(AspNetRole entity, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(aspNetRole => aspNetRole.Id == entity.Id, navigationProperties).ConfigureAwait(false);
        }

        protected override bool ValidateEntity(AspNetRole entity)
        {
            if (string.IsNullOrEmpty(entity?.Id) && entity.Id != Guid.Empty.ToString())
            {
                return true;
            }

            LogHelper.LogException<BaseDataRepository>("Invalid entity: null or empty primaty keys");
            return false;
        }
         */

        public IList<DisplayCategory> GetMoviesByCategories()
        {
            IList<DisplayCategory> mappedCategory = new List<DisplayCategory>();
            var categoryList = GetList(category => category.Status == (int)EntityStatus.ACTIVE, new string[]
                                {
                                    $"{nameof(Category.MovieList)}.{nameof(Movie.TagList)}.{nameof(TagsMovieAssignment.Tag)}"
                                });

            try
            {
                mappedCategory = mMapper.Map<IList<DisplayCategory>>(categoryList);
                //mappedCategory = mMapper.Map<DisplayCategory>(categoryList);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + "vali si alex");

            }

            return mappedCategory;
        }
    }
}
