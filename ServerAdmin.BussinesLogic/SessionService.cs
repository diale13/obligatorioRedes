using ServerAdmin.InterfacesBussinesLogic;
using System;

namespace ServerAdmin.BussinesLogic
{
    public class SessionService : ISessionService
    {
        public Guid? CreateToken(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool DeleteLoggedUser(string token)
        {
            throw new NotImplementedException();
        }

        public bool IsValidToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
