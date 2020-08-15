using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
    public interface IUserRepository:IBaseRepository<User>
    {
        User GetByPhone(string phone);
    }
}
