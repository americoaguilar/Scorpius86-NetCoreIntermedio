using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Web.API.Postman.Data.Context;
using Galaxy.Web.API.Postman.Data.Entities;
using Galaxy.Web.API.Postman.Security;
using Galaxy.Web.API.Postman.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Galaxy.Web.API.Postman.Models;

namespace Galaxy.Web.API.Postman
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
            JwtSettings jwtSettings = GetJwtSettings();
            services.AddSingleton<JwtSettings>(jwtSettings);

            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            string conStr = Configuration["connectionStrings:libraryConnectionString"];
            services.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(conStr));
            
            services.AddScoped<ILibraryRepository, LibraryRepository>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "JwtBearer";
                opt.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtOpt =>
             {
                 jwtOpt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                     ValidateIssuer = true,
                     ValidIssuer = jwtSettings.Issuer,
                     ValidateAudience = true,
                     ValidAudience = jwtSettings.Audience,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.FromMinutes(jwtSettings.MinutesToExpiration)
                 };
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<AuthorDto, Author>();
                cfg.CreateMap<Book, BookDto>();
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }

        protected JwtSettings GetJwtSettings()
        {
            JwtSettings jwtSettings = new JwtSettings();

            jwtSettings.Key = Configuration["JwtSettings:key"];
            jwtSettings.Audience = Configuration["JwtSettings:audience"];
            jwtSettings.Issuer = Configuration["JwtSettings:issuer"];
            jwtSettings.MinutesToExpiration = Convert.ToInt32(Configuration["JwtSettings:minuteExpiration"]);

            return jwtSettings;
        }
    }
}
