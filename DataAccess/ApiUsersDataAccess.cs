﻿using DataAccess.Exceptions;
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

        public void Update(ApiUser userToUpdate)
        {
            try
            {
                semaphore.WaitAsync();
                var indexToModify = users.FindIndex(gen => gen.NickName.Equals(userToUpdate.NickName));
                if (indexToModify == -1)
                {
                    throw new DataBaseException("No se encontro el usuario solicitado");
                }
                users[indexToModify] = userToUpdate;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
