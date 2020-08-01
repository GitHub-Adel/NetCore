using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Api;

namespace SocialMedia.Core.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();

    }
}
