﻿using DataAccess;
using IDataAccess;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SessionService : MarshalByRefObject, ISessionService
    {
        private IApiUsersDataAccess apiUsersDataAccess = new ApiUsersDataAccess();
        private static IDictionary<string, string> TokenRepository = new Dictionary<string, string>();

        public Guid? CreateToken(string userName, string password)
        {
            var users = apiUsersDataAccess.GetAll();
            var user = users.FirstOrDefault(x => x.NickName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var token = Guid.NewGuid();
            TokenRepository.Add(token.ToString(), user.NickName);
            return token;
        }

        public bool DeleteLoggedUser(string token)
        {
            if (!TokenRepository.Remove(token))
            {
                return false;
            }
            return true;
        }

        public bool IsValidToken(string token)
        {
            return TokenRepository.ContainsKey(token);
        }

        public string GetUserByToken(string token)
        {
            if (IsValidToken(token))
            {
                return TokenRepository[token];
            }
            return "null";
        }
           
    }
}
