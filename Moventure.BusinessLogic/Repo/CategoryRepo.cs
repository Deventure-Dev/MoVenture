using Moventure.DataLayer.Models;
using System;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class CategoryRepo : BaseSinglePkRepository<Categories>
    {
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
    }
}
