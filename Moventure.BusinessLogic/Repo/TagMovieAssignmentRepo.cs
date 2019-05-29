using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class TagMovieAssignmentRepo : BaseRepository<TagsMovieAssignment>
    {
        public override TagsMovieAssignment FetchFromDb(TagsMovieAssignment entity, IList<string> navigationProperties = null)
        {
            return GetSingle(e => e.MovieId == entity.MovieId && e.TagId == entity.TagId, navigationProperties);
        }

        public override async Task<TagsMovieAssignment> FetchFromDbAsync(TagsMovieAssignment entity, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(e => e.MovieId == entity.MovieId && e.TagId == entity.TagId, navigationProperties).ConfigureAwait(false);
            throw new NotImplementedException();
        }

        public override bool ValidateEntity(TagsMovieAssignment entity)
        {
            if (entity.MovieId != Guid.Empty && entity.TagId != Guid.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
