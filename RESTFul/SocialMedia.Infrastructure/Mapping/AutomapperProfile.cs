using System;
using AutoMapper;
using SocialMedia.Core;
using SocialMedia.Core.DTO;

namespace SocialMedia.Infrastructure.Mapping
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
