using System;
using AutoMapper;
using SocialMedia.Api.DTOs;
using SocialMedia.Api.Models;
using static SocialMedia.Api.Controllers.UserController;

namespace SocialMedia.Api.Mappings
{
public class AutomapperProfile:Profile
{
	public AutomapperProfile()
	{
		CreateMap<User,UserDTO>(); 
		CreateMap<UserDTO,User>(); 

		CreateMap<Role,RoleDTO>(); 
		CreateMap<RoleDTO,Role>(); 

		CreateMap<Security,SecurityDTO>(); 
		CreateMap<SecurityDTO,Security>(); 
	}	
}
}
