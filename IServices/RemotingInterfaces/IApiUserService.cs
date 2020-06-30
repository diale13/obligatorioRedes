using Domain;

namespace IServices
{
    public interface IApiUserService
    {
        void AddUser(ApiUser user);
        bool UpdateUser(ApiUser user);
        ApiUser GetUser(string nickName);
        bool DeleteUser(string nicknName, string password);
    }
}
