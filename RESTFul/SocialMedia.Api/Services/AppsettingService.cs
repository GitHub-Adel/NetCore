using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using SocialMedia.Api.Interfaces;

namespace SocialMedia.Api.Services
{
    public class AppsettingService : IAppsettingService
    {
        private readonly IConfiguration configuration;
        public AppsettingService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string SocialMediaConnection => configuration["SocialMediaConnection"];

        public int ItemByPage => int.Parse(configuration["ItemByPage"]);

        public int CurrentPage => int.Parse(configuration["CurrentPage"]);

        public byte[] SecretKey => Encoding.UTF8.GetBytes(configuration["SecretKey"]);

        public string Issuer => configuration["Issuer"];

        public string Audience => configuration["Audience"];
        public double TokenMinuteExpires => double.Parse(configuration["TokenMinuteExpires"]);
    }
}
