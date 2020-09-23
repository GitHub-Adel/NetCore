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
        private readonly IMapper _mapper;
        private readonly IUser _user;
        private readonly IPagination<User> _pagination;
        public UserController(IMapper mapper, IUser _user, IPagination<User> _pagination)
        {
            this._mapper = mapper;
            this._user = _user;
            this._pagination = _pagination;
        }

        [HttpPost(Name=nameof(SaveUser))]
        public async Task<IActionResult> SaveUser(UserDTO userDTO)
        {
            //mapeo, guardo, recupero, mapeo respuesta y la devuelvo
            var user = _mapper.Map<User>(userDTO);
            user = await _user.AddUserAsync(user);
            userDTO = _mapper.Map<UserDTO>(user);
            var response = new Dictionary<string, object>()
            {
                {"User",userDTO},
            };
            return Ok(response);
        }


        [HttpGet(Name =nameof(GetUsers))]
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters)
        {
            //obtengo la collection de user
            var users = _user.GetByFilters(filters);
            //pagino la lista y retorno una pagina
            var usersPagedList = _pagination.GetPagedList(users, filters.ItemByPage, filters.CurrentPage);
            //creo la navegacion para el paginado de una lista(next=3, previous=1, TotalItem=20 etc.).
            var navegation = _pagination.GetNavegation(users, filters.ItemByPage, filters.CurrentPage);
            //mapeo usersPagedList al usersDTO
            var usersDTO = _mapper.Map<List<UserDTO>>(usersPagedList);
            //agrego los links para HATEOAS O HYPERMEDIA de este recurso
            usersDTO.ForEach(x=>{
                x.Links.Add("Href:",Url.Link(nameof(SaveUser),new{FirstName=x.Firstname}));
                x.Links.Add("Rel:","Edit-user");
                x.Links.Add("Method:","PUT");
            });
            //para ir listando la respuesta en formato clave,valor ej:  
            var response = new Dictionary<string, object>()
            {
                {"Users",usersDTO},
                {"Navegationn",navegation},                
                {"Save user",Url.Link(nameof(SaveUser),new{}) },
            };
            return Ok(response);
        }


        [HttpGet("{id}",Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            //obtengo el user
            var user =await _user.GetByIdAsync(id);
            //mapeo user userDTO
            var userDTO = _mapper.Map<UserDTO>(user);

            //para ir listando la respuesta en formato clave,valor ej:  
            var response = new Dictionary<string, object>()
            {
                {"User",userDTO},
               // {"Getcomment",Url.Link(nameof(GetComment),new {CommentId=1}) }
            };
            return Ok(response);
        }




    }



}
