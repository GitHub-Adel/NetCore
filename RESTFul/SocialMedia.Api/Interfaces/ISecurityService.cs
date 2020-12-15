using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Interfaces
{
    public interface ISecurityService
    {
        Task<ResponseApi<SecurityDTO>> AddAsync(SecurityDTO SecurityDTO);
        ResponseApi<List<SecurityDTO>> Get(SecurityQueryFilter filters);
        Task<ResponseApi<SecurityDTO>> UpdateAsync(SecurityDTO SecurityDTO);
    }

}
