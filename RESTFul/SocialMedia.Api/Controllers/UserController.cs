using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;


namespace SocialMedia.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUser _user;
        private readonly IPagination<User> _pagination;

        public UserController(IMapper mapper, IUser _user, IPagination<User> _pagination)
        {
            this.mapper = mapper;
            this._user = _user;
            this._pagination = _pagination;
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDTO userDTO)
        {
            //mapeo, guardo, recupero, mapeo respuesta y la devuelvo
            var user = mapper.Map<User>(userDTO);
                user =  await _user.AddUserAsync(user);
            var response = new Dictionary<string,object>(){{"User",user}};
            return Ok(response);
        }


        [HttpGet]
        public  IActionResult GetUsers([FromQuery]UserQueryFilter filters)
        {  
            //obtengo la collection de user
            var users = _user.GetByFilters(filters); 
            //pagino la lista y retorno una pagina
            var usersPagedList=_pagination.GetPagedList(users, filters.ItemByPage, filters.CurrentPage); 
            //creo la navegacion para el paginado de una lista(next=3, previous=1, TotalItem=20 etc.).
            var navegation=_pagination.GetNavegation(users, filters.ItemByPage, filters.CurrentPage);                        
            //mapeo usersPagedList al usersDTO
            var usersDTO= mapper.Map<IEnumerable<UserDTO>>(usersPagedList);
               
            //para ir listando la respuesta en formato clave,valor ej:  
            var response = new Dictionary<string, object>()   
            {
                {"Users",usersDTO},
                {"Navegacion",navegation},
               // {"Save user",Url.Link() }
            };                          
            return Ok(response);
        }





    }


    
}
