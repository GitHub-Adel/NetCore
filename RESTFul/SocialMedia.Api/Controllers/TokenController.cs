using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.DTOs;
namespace SocialMedia.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _token;
        public TokenController(ITokenService _token)
        {
            this._token = _token;
        }

        [HttpGet(Name = nameof(Authentication))]
        public IActionResult Authentication(CredentialDTO credentialDTO)
        {
            var response = _token.Get(credentialDTO);
            return Ok(response);
        }

    }
}
