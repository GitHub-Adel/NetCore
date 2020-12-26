using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Models;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Services
{

    public class RoleService :BaseService<Role,RoleDTO>, IRoleService
    {
        public RoleService(SocialmediaDBContext _context,  IMapper _mapper, IPaginationService<Role> _pagination) : base(_context, _mapper, _pagination)
        {
        }

        public async Task<ResponseApi<RoleDTO>> AddAsync(RoleDTO roleDTO)
        {
            try
            {
              //logica de negocio
              roleDTO.RoleId=0;
              ExceptionIfNoExist(x=>x.Name==roleDTO.Name && x.Active==true);
              //inserto la entidad
              roleDTO =  await AddEntityAsync(roleDTO);
            }
            catch (Exception ex)
            {
               new CustomException(ex);
            }
            //retorno DTO con respuesta personalizaa
            return new ResponseApi<RoleDTO>(roleDTO);
        }

        public async Task<ResponseApi<RoleDTO>> UpdateAsync(RoleDTO roleDTO)
        {
            try
            {
                //logica de negocio
                ExceptionIfNoExist(x=>x.RoleId==roleDTO.RoleId);
                //actualizo la entidad
                roleDTO =  await UpdateEntityAsync(roleDTO);
            }
            catch (Exception ex)
            {
               new CustomException(ex);
            }
            //retorno DTO con respuesta personalizada
            return new ResponseApi<RoleDTO>(roleDTO);
        }


        public ResponseApi<List<RoleDTO>> Get(RoleQueryFilter filters)
        {
             //obtenemos IEnumerable
            var list = _entity.AsEnumerable();
            //aplicamos filtros
            if (filters.RoleId != null)
                list = list.Where(x => x.RoleId.Equals(filters.RoleId));
            if (filters.Name != null)
                list = list.Where(x => x.Name.ToLower().Contains(filters.Name.ToLower()));           

            return GetPagedList(list,filters);
        }


    }
}
