using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.Interface;
using SocialMedia.Core.Services;
using SocialMedia.Infrastructure;
using SocialMedia.Infrastructure.Repository;

namespace SocialMedia.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(x=>{
                x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            })  ;

            services.AddDbContext<SocialmediaDBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SocialMedia")));
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //definir en el startup, el repository que usara la interface. 
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();           
            //para interface generica.
            //services.AddScoped( typeof(IBaseRepository<>), typeof(BaseRepository<>) );
                   
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
