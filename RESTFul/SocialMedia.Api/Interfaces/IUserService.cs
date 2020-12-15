using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Models;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Interfaces
{
    public interface IUserService
    {
        Task<ResponseApi<UserDTO>> AddAsync(UserDTO user);
        Task<ResponseApi<UserDTO>> UpdateAsync(UserDTO userDTO);
        ResponseApi<List<UserDTO>> Get(UserQueryFilter filters);
    }
}
