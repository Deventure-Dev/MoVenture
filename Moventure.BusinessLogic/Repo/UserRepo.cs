using Moventure.DataLayer.Models;
using System;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class UserRepo : BaseSinglePkRepository<Users>
    {
        public object GetUserData(string email)
        {
             var feGetSingle(user => user.Email == email);
        }
    }
}
