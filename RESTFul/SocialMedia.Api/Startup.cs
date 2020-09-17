using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Services;
using SocialMedia.Infrastructure.Filters;

namespace SocialMedia.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(x =>
            {
                x.Filters.Add<GlobalExceptionFilter>();
            }).AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            
            //services.AddDbContext<SocialmediaDBContext>(x => x.UseSqlServer(configuration["SocialMediaConnection"]));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //configurar los servicios para dependency injection
            services.AddTransient<IAppsetting, AppsettingService>();
            services.AddTransient<IUser, UserService>();
            services.AddScoped(typeof(IPagination<>), typeof(PaginationService<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
