using DataAccess;
using DataAccess.Exceptions;
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

        public bool DeleteUser(string nicknName, string password)
        {
            try
            {
                dataAccess.Delete(nicknName, password);
                return true;
            }
            catch (DataBaseException)
            {
                return false;                
            }
          
        }

        public ApiUser GetUser(string nickName)
        {
            return dataAccess.Get(nickName);
        }

        public bool UpdateUser(ApiUser user)
        {
            try
            {
                dataAccess.Update(user);
                return true;
            }
            catch (DataBaseException)
            {
                return false;
            }

        }


    }
}
