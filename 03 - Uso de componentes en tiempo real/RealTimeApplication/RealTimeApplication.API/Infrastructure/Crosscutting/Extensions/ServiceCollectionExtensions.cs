using Microsoft.Extensions.DependencyInjection;
using RealTimeApplication.API.Application.Order;
using RealTimeApplication.API.Application.Product;
using RealTimeApplication.API.Application.Tracking;
using RealTimeApplication.API.Infrastructure.Data.Repositories.Order;
using RealTimeApplication.API.Infrastructure.Data.Repositories.Product;
using RealTimeApplication.API.Infrastructure.Data.Repositories.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Infrastructure.Crosscutting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITrackingRepository, TrackingRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IOrderApplicationServices, OrderApplicationServices>();
            services.AddTransient<ITrackingApplicationServices, TrackingApplicationServices>();
            services.AddTransient<IClientApplicationServices, ClientApplicationServices>();
            services.AddTransient<IProductApplicationServices, ProductApplicationServices>();
        }
    }
}
