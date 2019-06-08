using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class PlaylistMovieAssignmentRepo : BaseRepository<PlaylistMovieAssignment>
    {
        public override PlaylistMovieAssignment FetchFromDb(PlaylistMovieAssignment entity, IList<string> navigationProperties = null)
        {
            return GetSingle(assignment => assignment.MovieId == entity.MovieId &&
                                           assignment.PlaylistId == entity.PlaylistId, navigationProperties);
        }

        public override async Task<PlaylistMovieAssignment> FetchFromDbAsync(PlaylistMovieAssignment entity, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(assignment => assignment.MovieId == entity.MovieId &&
                                                      assignment.PlaylistId == entity.PlaylistId, navigationProperties).ConfigureAwait(false);
        }

        public override bool ValidateEntity(PlaylistMovieAssignment entity)
        {
            if (entity.MovieId != Guid.Empty && entity.PlaylistId != Guid.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
