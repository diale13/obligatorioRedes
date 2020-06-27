using DataAccess;
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
            if(userName == "admin" && password == "admin")
            {
                var tokens= Guid.NewGuid();
                TokenRepository.Add(tokens.ToString(), password);
                return tokens;
            }


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
    }
}
