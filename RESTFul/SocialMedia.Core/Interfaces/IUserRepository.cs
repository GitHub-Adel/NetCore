using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        User GetByPhone(string phone);
    }
}
