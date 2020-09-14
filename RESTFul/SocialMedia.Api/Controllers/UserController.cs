using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
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


        [HttpGet]
        public  IActionResult GetUsers([FromQuery]UserQueryFilter filters)
        {
            var result = _service.GetByFilters(filters);                      
            var response= new ApiResponse<IEnumerable<User>>(result,result.Pagination);            
            return Ok(response);
        }





    }


    
}
