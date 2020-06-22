using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IDataAccess;
using Persistance;

namespace DataAccess
{
    public class ClientDataAccess : IClientDataAccess
    {
        private List<User> users = MemoryDataBase.GetInstance().Users;
        private readonly Object userLock = new object();


        public List<User> GetClients()
        {
            lock (userLock)
            {
                return users;
            }
        }

        public int AmountOfClients()
        {
            lock (userLock)
            {
                return users.Count;
            }
        }

        public int AddClient(string dateTime)
        {
            lock (userLock)
            {
                int token = MemoryDataBase.GetInstance().UserTokenCount + 1;
                MemoryDataBase.GetInstance().UserTokenCount = MemoryDataBase.GetInstance().UserTokenCount + 1;
                User userToBeAdded = new User
                {
                    Id = token,
                    Time = dateTime
                };
                users.Add(userToBeAdded);
                return token;
            }
        }

        public void RemoveClient(int userId)
        {
            lock (userLock)
            {
                var indexToDelete = users.FindIndex(userInList => userInList.Id.Equals(userInList.Id));
                users.RemoveAt(indexToDelete);
            }
        }
    }
}
