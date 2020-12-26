using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SocialMedia.Api.Models;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.QueryFilters;
using SocialMedia.Api.DTOs;
using AutoMapper;
using SocialMedia.Api.CustomEntities;

namespace SocialMedia.Api.Services
{
    public class UserService :BaseService<User,UserDTO>, IUserService
    {
        public UserService(SocialmediaDBContext _context,  IMapper _mapper, IPaginationService<User> _pagination) : base(_context, _mapper, _pagination)
        {
        }

        public async Task<ResponseApi<UserDTO>> AddAsync(UserDTO userDTO)
        {            
            try
            {
            //   //logica de negocio
            //   userDTO.UserId=0;
            //   ExceptionIfExist(x=>x.Email==userDTO.Email && x.Active==true);
            //   ExceptionIfExist(x=>x.Phone==userDTO.Phone && x.Active==true);
            //   //inserto la entidad
               throw new CustomException("Error creado por Adelson",HttpStatusCode.BadRequest);
               userDTO =  await AddEntityAsync(userDTO);
               
            }
            catch (Exception ex)
            {
                new CustomException(ex);
            }
            //retorno DTO con respuesta personalizaa
            return new ResponseApi<UserDTO>(userDTO);
        }

        public async Task<ResponseApi<UserDTO>> UpdateAsync(UserDTO userDTO)
        {            
            try
            {
                //logica de negocio
                ExceptionIfNoExist(x=>x.UserId==userDTO.UserId);
                //actualizo la entidad
                userDTO =  await UpdateEntityAsync(userDTO);
            }
            catch (Exception ex)
            {
                new CustomException(ex);
            }
            //retorno DTO con respuesta personalizada
            return new ResponseApi<UserDTO>(userDTO);
        }


        public ResponseApi<List<UserDTO>> Get(UserQueryFilter filters)
        {
            //obtenemos IEnumerable
            var list = _entity.AsEnumerable();
            //aplicamos filtros
            if (filters.UserId != null)
                list = list.Where(x => x.UserId.Equals(filters.UserId));
            if (filters.Firstname != null)
                list = list.Where(x => x.Firstname.ToLower().Contains(filters.Firstname.ToLower()));
            if (filters.Lastname != null)
                list = list.Where(x => x.Lastname.ToLower().Contains(filters.Lastname.ToLower()));
            if (filters.Phone != null)
                list = list.Where(x => x.Phone.Equals(filters.Phone));

            return GetPagedList(list,filters);
        }
    }
}
