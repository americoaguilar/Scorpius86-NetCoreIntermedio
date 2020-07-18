using RealTimeApplication.API.Infrastructure.Data.Repositories.Order;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Application.Order
{
    public class OrderApplicationServices : IOrderApplicationServices
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApplicationServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderDto> List()
        {
            return _orderRepository.List();
        }

        public OrderDto GetByOrderId(int orderId)
        {
            return _orderRepository.GetByOrderId(orderId);
        }
        public OrderDto Update(int orderId,OrderDto order)
        {
            order.OrderId = orderId;
            return _orderRepository.Update(order);
        }

        public OrderDto Insert(OrderDto order)
        {
            return _orderRepository.Insert(order);
        }
        public OrderDto Delete(int orderId)
        {
            return _orderRepository.Delete(orderId);
        }
    }
}
