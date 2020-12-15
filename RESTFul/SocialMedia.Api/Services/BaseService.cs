using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Models;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Services
{
    public abstract class BaseService<TEntity, TDTO> where TEntity : class where TDTO : class
    {
        internal readonly SocialmediaDBContext _context;
        internal readonly DbSet<TEntity> _entity;
        internal readonly IGlobalExceptionService _exception;
        internal readonly IMapper _mapper;
        internal readonly IPaginationService<TEntity> _pagination;
        public BaseService(SocialmediaDBContext _context, IGlobalExceptionService _exception, IMapper _mapper, IPaginationService<TEntity> _pagination)
        {
            this._pagination = _pagination;
            this._mapper = _mapper;
            this._exception = _exception;
            this._context = _context;
            _entity = _context.Set<TEntity>();
        }


        internal ResponseApi<List<TDTO>> GetPagedList(IEnumerable<TEntity> lista, BaseQueryFilter filter=null)
        {
            var list = lista.ToList();
            //aplicamos logica de negocio
            if (list.Count() == 0)
                _exception.CustomException($"No se encontro resultado", HttpStatusCode.NotFound);
            //aplicamos navegacion de la lista
            var navegation = _pagination.GetNavegation(list, filter);
            //aplicamos paginado
            var pagedList = _pagination.GetPagedList(list, filter);
            //mapeamos la lista paginada a un DTOs
            var dTOs = _mapper.Map<List<TDTO>>(pagedList);
            //retornamos nuestra repuesta personalizada.
            return new ResponseApi<List<TDTO>>(dTOs, navegation);
        }

        internal async Task<TDTO> UpdateEntityAsync(TDTO dTO)
        {
            //mapeo el DTO a una entidad
            var entity = _mapper.Map<TEntity>(dTO);
            _entity.Update(entity);
            await _context.SaveChangesAsync();
            //mapeo a un DTO
            dTO = _mapper.Map<TDTO>(entity);
            return dTO;
        }
        internal async Task<TDTO> AddEntityAsync(TDTO dTO)
        {
            //mapeo el DTO a una entidad
            var entity = _mapper.Map<TEntity>(dTO);
            _entity.Add(entity);
            await _context.SaveChangesAsync();
            //mapeo a un DTO
            dTO = _mapper.Map<TDTO>(entity);
            return dTO;
        }
        
        internal void ExceptionIfExist(Func<TEntity, bool> predicate)
        {
            //AsNoTracking() : es para dejar de seguir la entidad y que no me de error 
            //al llamar el update(entitty)
            var entity = _entity.AsNoTracking().FirstOrDefault(predicate);
            if (entity != null) _exception.CustomException($"{entity.GetType().Name} ya existe", HttpStatusCode.Conflict);
        }
        internal void ExceptionIfNoExist(Func<TEntity, bool> predicate)
        {
            //AsNoTracking() : es para dejar de seguir la entidad y que no me de error 
            //al llamar el update(entitty)
            var entity = _entity.AsNoTracking().FirstOrDefault(predicate);
            if (entity == null) _exception.CustomException($"{entity.GetType().Name} no existe", HttpStatusCode.NotFound);
        }
    }
}
