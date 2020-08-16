using System;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
    }
}
