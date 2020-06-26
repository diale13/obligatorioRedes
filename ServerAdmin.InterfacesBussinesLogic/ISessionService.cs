using System;

namespace ServerAdmin.InterfacesBussinesLogic
{
    public interface ISessionService
    {
        bool IsValidToken(string token);

        Guid? CreateToken(string userName, string password);

        bool DeleteLoggedUser(string token);
    }
}
