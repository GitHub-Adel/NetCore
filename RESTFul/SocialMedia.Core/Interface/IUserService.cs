using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
    }
}
