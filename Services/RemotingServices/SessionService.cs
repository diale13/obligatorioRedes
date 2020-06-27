using IServices;
using System;

namespace Services
{
    public class SessionService : MarshalByRefObject, ISessionService
    {
        public Guid? CreateToken(string userName, string password)
        {
            return new Guid();
            throw new NotImplementedException();
        }

        public bool DeleteLoggedUser(string token)
        {
            return true;
            throw new NotImplementedException();
        }

        public bool IsValidToken(string token)
        {
            return true;
            throw new NotImplementedException();
        }
    }
}
