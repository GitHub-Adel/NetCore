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
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        public UserController(IUserService _user)
        {
            this._user = _user;
        }

        [HttpPost(Name=nameof(AddUser))]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {            
            var response = await _user.AddAsync(userDTO);            
            return Ok(response);
        }

        [HttpPut("{id}",Name=nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
        {            
            userDTO.UserId=id;
            var response = await _user.UpdateAsync(userDTO);            
            return Ok(response);
        }

        [HttpGet(Name=nameof(GetUsers))]
        public  IActionResult GetUsers([FromQuery] UserQueryFilter filters)
        {                        
            var response =  _user.Get(filters);            
            return Ok(response);
        }

    }

}
