using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Application.Order
{
    public interface IOrderApplicationServices
    {
        OrderDto Delete(int orderId);
        OrderDto GetByOrderId(int orderId);
        OrderDto Insert(OrderDto order);
        List<OrderDto> List();
        OrderDto Update(int orderId, OrderDto order);
    }
}