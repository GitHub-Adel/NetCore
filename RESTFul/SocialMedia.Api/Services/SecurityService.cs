using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Models;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Services
{
    public class SecurityService : BaseService<Security, SecurityDTO>, ISecurityService
    {
        private readonly IAppsettingService _appsetting;
        public SecurityService(SocialmediaDBContext _context, IGlobalExceptionService _exception, IMapper _mapper, IPaginationService<Security> _pagination, IAppsettingService _appsetting) : base(_context, _exception, _mapper, _pagination)
        {
            this._appsetting = _appsetting;
        }

        public async Task<ResponseApi<SecurityDTO>> AddAsync(SecurityDTO SecurityDTO)
        {
            try
            {
                //logica de negocio
                SecurityDTO.SecurityId = 0;
                ExceptionIfExist(x => x.User == SecurityDTO.User && x.Active == true);
                //inserto la entidad
                SecurityDTO = await AddEntityAsync(SecurityDTO);
                //SecurityDTO.Password=null;
            }
            catch (Exception ex)
            {
                _exception.CatchException(ex);
            }
            //retorno DTO con respuesta personalizaa
            return new ResponseApi<SecurityDTO>(SecurityDTO);
        }

        public async Task<ResponseApi<SecurityDTO>> UpdateAsync(SecurityDTO SecurityDTO)
        {
            try
            {
                //logica de negocio
                ExceptionIfNoExist(x => x.SecurityId == SecurityDTO.SecurityId);
                //actualizo la entidad
                SecurityDTO = await UpdateEntityAsync(SecurityDTO);
            }
            catch (Exception ex)
            {
                _exception.CatchException(ex);
            }
            //retorno DTO con respuesta personalizada
            return new ResponseApi<SecurityDTO>(SecurityDTO);
        }


        public ResponseApi<List<SecurityDTO>> Get(SecurityQueryFilter filters)
        {
            //obtenemos IEnumerable
            var list = _entity.AsEnumerable();
            //aplicamos filtros
            if (filters.SecurityId != null)
                list = list.Where(x => x.SecurityId.Equals(filters.SecurityId));
            if (filters.RoleId != null)
                list = list.Where(x => x.RoleId.Equals(filters.RoleId));
            if (filters.User != null)
                list = list.Where(x => x.User.Contains(filters.User));
            if (filters.Name != null)
                list = list.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));
            if (filters.Active != null)
                list = list.Where(x => x.Active.Equals(filters.Active));

            return GetPagedList(list, filters);
        }


    }
}
