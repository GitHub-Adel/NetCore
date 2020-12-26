using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Models;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly IMapper _mapper;
        public UserController(IUserService _user, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._user = _user;
        }

        [HttpPost(Name = nameof(AddUser))]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            var response = await _user.AddAsync(userDTO);
            return Ok(response);
        }

        [HttpPut("{id}", Name = nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {
            userDTO.UserId = id;
            var response = await _user.UpdateAsync(userDTO);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = nameof(DeleteUser))]
        public IActionResult DeleteUser(int id)
        {
            return null;
        }





        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters)
        {
            var usuarios = new List<Usuario>(){
                new Usuario(){UsuarioId=1,Nombre="adelson"},
                new Usuario(){UsuarioId=2,Nombre="Rosalis"},
            };

            var usuarioDTOs=_mapper.Map<List<UsuarioDTO>>(usuarios);

            var response = usuarioDTOs;//_user.Get(filters);            
            return Ok(response);
        }



        public class Link2
        {
            public string Href { get; set; } //Ruta o endpoint ej: https://localhost:5001/api/User
            public string Rel { get; set; }  //lo que hace el endpoint ej: ActualizarCliente
            public string Method { get; set; } //verbo http ej: POST,GET ETC.
        }
        public class UsuarioDTO
        {
            public int UsuarioId { get; set; }
            public string Nombre { get; set; }
            public IList<Link2> Links { get; set; } = new List<Link2>();

            public UsuarioDTO(int id, string nombre, IUrlHelper url)
            {
                UsuarioId = id;
                Nombre = nombre;
                this.Links = new List<Link2>(){
                     new Link2{Rel="Actualizar",Method="PUT",Href=url.Link("UpdateUser", new {Id=id })}
                     ,new Link2{Rel="Eliminar",Method="PUT",Href=url.Link("DeleteUser", new {Id=id })}
                };

            }

            public UsuarioDTO()
            {
                IUrlHelper url=default(IUrlHelper);
                this.Links = new List<Link2>(){
                     new Link2{Rel="Actualizar",Method="PUT",Href=url.Link("UpdateUser", new {Id=UsuarioId })}
                     ,new Link2{Rel="Eliminar",Method="PUT",Href=url.Link("DeleteUser", new {Id=UsuarioId })}
                };
            }

        }

        public class Usuario
        {
            public int UsuarioId { get; set; }
            public string Nombre { get; set; }
        }




    }




}
