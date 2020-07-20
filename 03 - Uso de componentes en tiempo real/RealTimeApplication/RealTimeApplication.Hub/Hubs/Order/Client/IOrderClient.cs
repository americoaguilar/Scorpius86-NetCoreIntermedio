using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.HUB.Hubs.Order.Client
{
    public interface IOrderClient:IOrderOperations,IClientOperations,ITrackingOperations,IProductOperations
    {
        //IOrderOperations OrderOperations { get; set; }
        //IClientOperations ClientOperations { get; set; }
        //ITrackingOperations TrackingOperation { get; set; }
        //IProductOperations ProductOperations { get; set; }
    }
}
