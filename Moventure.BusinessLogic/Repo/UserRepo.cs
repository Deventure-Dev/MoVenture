using AutoMapper;
using Moventure.BusinessLogic.Helpers;
using Moventure.DataLayer.Models;
using Moventure.Models;
using System;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class UserRepo : BaseSinglePkRepository<Users>
    {
        private readonly IMapper mMapper;

        public UserRepo(IMapper mapper = null)
        {
            mMapper = mapper;
            var mapper2 = ServiceProviderHelper.ServiceProvider.GetService(typeof(IMapper));
        }

        public UserData GetUserData(string email)
        {
            var fetchedUser = GetSingle(user => user.Email == email);
                 return new UserData {
                    User = mMapper.Map<User>(fetchedUser)
               
                };
            }
    }
}
