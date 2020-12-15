using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.QueryFilters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SocialMedia.Api.Controllers
{
    [Authorize(Roles="Administrator")]
    [ApiController]
    [Route("api/[Controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _Security;
        public SecurityController(ISecurityService _Security)
        {
            this._Security = _Security;
        }

        [HttpPost(Name = nameof(AddSecurity))]
        public async Task<IActionResult> AddSecurity(SecurityDTO SecurityDTO)
        {
            var response = await _Security.AddAsync(SecurityDTO);
            return Ok(response);
        }

        [HttpPut("{id}", Name = nameof(UpdateSecurity))]
        public async Task<IActionResult> UpdateSecurity(int id, SecurityDTO SecurityDTO)
        {
            SecurityDTO.SecurityId = id;
            var response = await _Security.UpdateAsync(SecurityDTO);
            return Ok(response);
        }

        [HttpGet(Name = nameof(GetSecuritys))]
        public IActionResult GetSecuritys([FromQuery] SecurityQueryFilter filters)
        {
            var response = _Security.Get(filters);
            return Ok(response);
        }

    }
}
