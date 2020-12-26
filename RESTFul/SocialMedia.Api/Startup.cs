using System;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.Filters;
using SocialMedia.Api.Models;
using SocialMedia.Api.Services;

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
            services.AddAuthentication(x=>{
               x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;     
               x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>{
                x.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer=configuration["Issuer"],
                    ValidAudience=configuration["Audience"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"]))
                };
            });    

            services.AddControllers(x =>
            {
                x.Filters.Add<GlobalExceptionFilter>();
            }).AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            
            services.AddDbContext<SocialmediaDBContext>(x => x.UseSqlServer(configuration["SocialMediaConnection"]));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(x=>{
                x.SwaggerDoc("v1",new OpenApiInfo{Title="Social Media Api",Version="v1"});
                var xmlfile=$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlpath=Path.Combine(AppContext.BaseDirectory,xmlfile);
                x.IncludeXmlComments(xmlpath);
            });


            //configurar los servicios para dependency injection
            services.AddTransient<IAppsettingService, AppsettingService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped(typeof(IPaginationService<>), typeof(PaginationService<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(x=>{
                x.SwaggerEndpoint( "/swagger/v1/swagger.json","Social Media Api v1");
                x.RoutePrefix=string.Empty;
            });
                               

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
