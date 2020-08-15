using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Response;
using SocialMedia.Core;
using SocialMedia.Core.DTO;
using SocialMedia.Core.Interface;

namespace SocialMedia.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper mapper;

        public UserController(IUserService _service, IMapper mapper)
        {
            this._service = _service;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            //mapeo, guardo, recupero, mapeo, creo respuesta y la retorno
            var user = mapper.Map<User>(userDTO);
            var result = await _service.Add(user);
                userDTO = mapper.Map<UserDTO>(result);
            var response = new ApiResponse<UserDTO>(userDTO);
            return Ok(response);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        // {
        //     //mapeo, actualizo y respondo
        //     var user = mapper.Map<User>(userDTO);
        //     user.UserId = id;
        //     var result = await _service.UpdateUser(user);
        //         userDTO=mapper.Map<UserDTO>(result);
        //     var response = new ApiResponse<UserDTO>(userDTO);
        //     return Ok(response);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetUser(int id)
        // {
        //     //recupero, mapeo y devuelvo
        //     var result = await _service.GetUser(id);
        //     var userDTO = mapper.Map<UserDTO>(result);
        //     var response= new ApiResponse<UserDTO>(userDTO);
        //     return Ok(response);
        // }

        // [HttpGet]
        // public async Task<IActionResult> GetUsers()
        // {
        //     var result = await _service.GetUsers();
        //     var usersDTO = mapper.Map<IEnumerable<UserDTO>>(result);
        //     var response= new ApiResponse<IEnumerable<UserDTO>>(usersDTO);
        //     return Ok(response);
        // }





    }


    
}
