using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interface;

namespace SocialMedia.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;
        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("{id}")]
       public  async Task<IActionResult> GetUser(int id)
        {
            var model = await repo.GetUser(id);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var model = await repo.GetUsers();
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await repo.AddUser(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            await repo.UpdateUser(user);
            return Ok(user);
        }

    }
}
