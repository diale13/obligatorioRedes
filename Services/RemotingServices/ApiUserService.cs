using DataAccess;
using Domain;
using IDataAccess;
using IServices;
using System;

namespace Services
{
    public class ApiUserService : MarshalByRefObject, IApiUserService
    {
        private IApiUsersDataAccess dataAccess = new ApiUsersDataAccess();

        public void AddUser(ApiUser user)
        {
            dataAccess.Add(user);
        }

        public ApiUser GetUser(string nickName)
        {
            return dataAccess.Get(nickName);
        }

        public void UpdateUser(ApiUser user)
        {
            dataAccess.Update(user);
        }
    }
}
