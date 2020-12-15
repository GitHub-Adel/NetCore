using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Models;
using SocialMedia.Api.QueryFilters;
using SocialMedia.Api.Services;

namespace SocialMedia.Api.Controllers
{

    namespace SocialMedia.Api.Controllers
    {
        [Authorize(Roles="Administrator")]
        [ApiController]
        [Route("api/[Controller]")]
        public class RoleController : ControllerBase
        {
            private readonly IRoleService _role;
            public RoleController(IRoleService _role)
            {
                this._role = _role;
            }

            [HttpPost(Name = nameof(AddRole))]
            public async Task<IActionResult> AddRole(RoleDTO roleDTO)
            {
                var response = await _role.AddAsync(roleDTO);
                //HATEOAS AND HYPERMEDIA
                response.Links=new List<Link>(){
                      new Link{Rel="Get-roles",Method="GET",Href=Url.Link(nameof(AddRole), new { })}
                     ,new Link{Rel="Update-role",Method="PUT",Href=Url.Link(nameof(UpdateRole), new { Id = roleDTO.RoleId })}
                };

                return Ok(response);
            }

            [HttpPut("{id}", Name = nameof(UpdateRole))]
            public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDTO)
            {
                roleDTO.RoleId = id;
                var response = await _role.UpdateAsync(roleDTO);
                //HATEOAS AND HYPERMEDIA
                response.Links=new List<Link>(){
                      new Link{Rel="Add-role",Method="POST",Href=Url.Link(nameof(AddRole), new { })}
                     ,new Link{Rel="Get-roles",Method="GET",Href=Url.Link(nameof(GetRoles), new { })}
                };

                return Ok(response);
            }
            
            [HttpGet(Name = nameof(GetRoles))]
            public IActionResult GetRoles([FromQuery] RoleQueryFilter filters)
            {
                //obtengo la collection de role
                var response = _role.Get(filters);
                //HATEOAS AND HYPERMEDIA
                response.Data.ForEach(x =>
                {                        
                    x.Links=new List<Link>(){
                        new Link{Rel="Update-role",Method="PUT",Href=Url.Link(nameof(UpdateRole), new { id = x.RoleId })}
                    };
                });

                response.Links=new List<Link>(){
                     new Link{Rel="Create-role",Method="POST",Href=Url.Link(nameof(AddRole), new { })},
                     new Link{Rel="Next",Method="GET",Href=Url.Link(nameof(GetRoles), new {CurrentPage=response.Navegation.Next})},
                     new Link{Rel="Previeus",Method="GET",Href=Url.Link(nameof(GetRoles), new { CurrentPage=response.Navegation.Previous})}
                };

                return Ok(response);
            }


        }
    }

}
