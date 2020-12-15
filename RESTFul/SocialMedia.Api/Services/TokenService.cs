using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Services
{
    public class TokenService : BaseService<Security, CredentialDTO>, ITokenService
    {
        private readonly IAppsettingService _appsetting;
        public TokenService(SocialmediaDBContext _context, IGlobalExceptionService _exception, IMapper _mapper, IPaginationService<Security> _pagination, IAppsettingService _appsetting) : base(_context, _exception, _mapper, _pagination)
        {
            this._appsetting = _appsetting;
        }

        public string Get(CredentialDTO credentialDTO)
        {
            //logica de negocio
            ExceptionIfNoExist(x => x.User == credentialDTO.User && x.Password == credentialDTO.Password);   

            //Header
            var a = new SymmetricSecurityKey(_appsetting.SecretKey);
            var b = new SigningCredentials(a, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(b);

            //Claims
            var security = _context.Security
                           .Include(x=>x.Role)
                           .Where(x => x.User == credentialDTO.User && x.Password == credentialDTO.Password)
                           .FirstOrDefault();                     
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,security.Name),
                new Claim("User",security.User),
                new Claim(ClaimTypes.Role, security.Role?.Name)
            };

            //Payload
            var payload = new JwtPayload
            (
                _appsetting.Issuer,
                _appsetting.Audience,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(_appsetting.TokenMinuteExpires)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
