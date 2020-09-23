using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Core.Interfaces
{
    public interface IUser
    {
        Task<User> AddUserAsync(User user);
        IEnumerable<User> GetByFilters(UserQueryFilter filters);
        Task<User> GetByIdAsync(int id);
    }
}
