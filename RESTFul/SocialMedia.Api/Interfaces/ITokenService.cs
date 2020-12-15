using SocialMedia.Api.DTOs;

namespace SocialMedia.Api.Interfaces
{
    public interface ITokenService
    {
        string Get(CredentialDTO credentialDTO);
    }

}
