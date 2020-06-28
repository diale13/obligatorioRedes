using Domain;

namespace IServices
{
    public interface IApiUserService
    {
        void AddUser(ApiUser user);
        void UpdateUser(ApiUser user);
        ApiUser GetUser(string nickName);
    }
}
