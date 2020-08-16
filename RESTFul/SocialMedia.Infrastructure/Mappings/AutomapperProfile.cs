using System;
using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infrastructure.Mappings
{
public class AutomapperProfile:Profile
{
	public AutomapperProfile()
	{
		CreateMap<User,UserDTO>(); 
		CreateMap<UserDTO,User>(); 
	}	
}
}
