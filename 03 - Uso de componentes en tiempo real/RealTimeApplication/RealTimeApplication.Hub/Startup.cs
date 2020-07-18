using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealTimeApplication.HUB.Hubs;

namespace RealTimeApplication.HUB
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            string redisConnectionString = "RealTimeApplication-CACHE.redis.cache.windows.net:6380,password=EoRxw4wUQYHdO7rdEIHKKr8RzH6UzLnei8yoPKwwer0=,ssl=True,abortConnect=False";
            services.AddCors(options =>
            {
                options.AddPolicy("signalr",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(hostName => true));
            });

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.Authority = "";
            //    options.Events = new JwtBearerEvents
            //    {
            //        OnMessageReceived = context =>
            //        {
            //            var accessToken = context.Request.Query["access_token"];
            //            var path = context.HttpContext.Request.Path;
            //            if (!string.IsNullOrEmpty(accessToken) &&
            //                (path.StartsWithSegments("/CoffeeHub")))
            //            {
            //                context.Token = accessToken;
            //            }
            //            return Task.CompletedTask;
            //        }
            //    };
            //});

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            })
            //.AddStackExchangeRedis(redisConnectionString, opt =>
            //{
            //    opt.Configuration.ChannelPrefix = "Coffee";
            //})
            .AddAzureSignalR(opt =>
            {
                opt.ConnectionString = "Endpoint=https://realtimeapplication-signalr.service.signalr.net;AccessKey=yw08R/mRHoU/SLRyNXR82DnriGRZN/BRNarkZ/mQ4Tg=;Version=1.0;";
            })
            .AddJsonProtocol(options => options.PayloadSerializerOptions.PropertyNamingPolicy = null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("signalr");
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<CoffeeHub>("/CoffeeHub");
            });
        }
    }
}
