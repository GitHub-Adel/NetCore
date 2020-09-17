using System;
using Microsoft.Extensions.Configuration;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class AppsettingService : IAppsetting
    {
        private readonly IConfiguration configuration;
        public AppsettingService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string SocialMediaConnection => configuration["SocialMediaConnection"];

        public int ItemByPage => int.Parse(configuration["ItemByPage"]);

        public int CurrentPage => int.Parse(configuration["CurrentPage"]);
    }
}
