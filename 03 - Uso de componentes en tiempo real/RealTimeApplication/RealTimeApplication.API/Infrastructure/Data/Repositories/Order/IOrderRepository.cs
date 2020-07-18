using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Infrastructure.Data.Repositories.Order
{
    public interface IOrderRepository
    {
        OrderDto Delete(int orderId);
        OrderDto GetByOrderId(int orderId);
        OrderDto Insert(OrderDto order);
        List<OrderDto> List();
        OrderDto Update(OrderDto order);
    }
}