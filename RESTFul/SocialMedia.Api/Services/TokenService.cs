using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Models;

namespace SocialMedia.Api.Services
{
    public class TokenService : BaseService<Security, CredencialDTO>, ITokenService
    {
        private readonly IAppsettingService _appsetting;
        public TokenService(SocialmediaDBContext _context, IMapper _mapper, IPaginationService<Security> _pagination, IAppsettingService _appsetting) : base(_context, _mapper, _pagination)
        {
            this._appsetting = _appsetting;
        }

        public string Get(CredencialDTO credentialDTO)
        {
            //logica de negocio
            ExceptionIfNoExist(x => x.User == credentialDTO.Usuario && x.Password == credentialDTO.Clave);   

            //Header
            var a = new SymmetricSecurityKey(_appsetting.SecretKey);
            var b = new SigningCredentials(a, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(b);

            //Claims
            var security = _context.Security
                           .Include(x=>x.Role)
                           .Where(x => x.User == credentialDTO.Usuario && x.Password == credentialDTO.Clave)
                           .FirstOrDefault();                     
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,security.Name),
                new Claim("Usuario",security.User),
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
