using Moventure.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class ActorMovieAssignmentRepo : BaseRepository<MovieActorAssignment>
    {
        public override MovieActorAssignment FetchFromDb(MovieActorAssignment entity, IList<string> navigationProperties = null)
        {
            return GetSingle(assignment => assignment.MovieId == entity.MovieId &&
                                           assignment.ActorId == entity.ActorId, navigationProperties);
        }

        public override async Task<MovieActorAssignment> FetchFromDbAsync(MovieActorAssignment entity, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(assignment => assignment.MovieId == entity.MovieId &&
                                                      assignment.ActorId == entity.ActorId, navigationProperties).ConfigureAwait(false);
        }

        public override bool ValidateEntity(MovieActorAssignment entity)
        {
            if (entity.MovieId != Guid.Empty && entity.ActorId != Guid.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
