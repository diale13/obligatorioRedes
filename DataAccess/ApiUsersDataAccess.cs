using Domain;
using IDataAccess;
using Persistance;
using System.Collections.Generic;
using System.Threading;

namespace DataAccess
{
    public class ApiUsersDataAccess : IApiUsersDataAccess
    {
        private List<ApiUser> users = MemoryDataBase.GetInstance().ApiUsers;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public void Add(ApiUser userToAdd)
        {
            try
            {
                semaphore.WaitAsync();
                users.Add(userToAdd);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public ApiUser Get(string nickname)
        {
            try
            {
                semaphore.WaitAsync();
                foreach (var u in users)
                {
                    if (u.NickName.Equals(nickname))
                    {
                        return u;
                    }
                }
                return null;
            }
            finally
            {
                semaphore.Release();
            }
        }

        public List<ApiUser> GetAll()
        {
            try
            {
                semaphore.WaitAsync();
                return users;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
