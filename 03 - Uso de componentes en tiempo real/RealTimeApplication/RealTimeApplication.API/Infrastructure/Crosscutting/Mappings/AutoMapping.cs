using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealTimeApplication.API.Infrastructure.Data.Entities;
using RealTimeApplication.Infrastructure.Dtos;

namespace RealTimeApplication.API.Infrastructure.Crosscutting.Mappings
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Tracking, TrackingDto>();
            CreateMap<TrackingDto, Tracking>();

            CreateMap<TrackingStatus, TrackingStatusDto>();
            CreateMap<TrackingStatusDto, TrackingStatus>();

            CreateMap<TrackingProduct, TrackingProductDto>();
            CreateMap<TrackingProductDto, TrackingProduct>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto,ProductDto>();

            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, ClientDto>();
        }
    }
}
