using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;

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
        public async Task<IActionResult> Save(UserDTO userDTO)
        {
            //mapeo, guardo, recupero, mapeo respuesta y la devuelvo
            var user = mapper.Map<User>(userDTO);
            var result =  await _service.AddUserAsync(user);
            var response = new ApiResponse<User>(result);
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
