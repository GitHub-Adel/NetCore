using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Interfaces
{
   public interface IRoleService
    {
        Task<ResponseApi<RoleDTO>> AddAsync(RoleDTO roleDTO);
        Task<ResponseApi<RoleDTO>> UpdateAsync(RoleDTO roleDTO);
        ResponseApi<List<RoleDTO>> Get(RoleQueryFilter filters);
    }
}