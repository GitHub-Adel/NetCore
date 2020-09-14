using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        PagedList<User> GetByFilters(UserQueryFilter filters);
    }
}
