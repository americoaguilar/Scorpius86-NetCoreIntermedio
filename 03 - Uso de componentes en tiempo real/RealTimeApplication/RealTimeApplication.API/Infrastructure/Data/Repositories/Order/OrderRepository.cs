using AutoMapper;
using RealTimeApplication.API.Infrastructure.Data.Contexts;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealTimeApplication.API.Infrastructure.Data.Repositories.Order
{
    using RealTimeApplication.API.Infrastructure.Data.Entities;
    public class OrderRepository : IOrderRepository
    {
        private readonly RealtimeapplicationContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(RealtimeapplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<OrderDto> List()
        {
            //var query = from o in _context.Orders
            //            join c in _context.Clients on o.ClientId equals c.ClientId
            //            join t in _context.Trackings on o.OrderId equals t.OrderId
            //            join tp in _context.TrackingProducts on t.TrackingId equals tp.TrackingId
            //            join p in _context.Products on tp.ProductId equals p.ProductId
            //            group p by o into grp
            //            select new OrderDto
            //            {
            //                OrderId = grp.Key.OrderId,
            //                ClientId = grp.Key.ClientId,
            //                Description = grp.Key.Description,
            //                Client = new ClientDto
            //                {
            //                    ClientId = grp.Key.Client.ClientId,
            //                    FileImageIcon = grp.Key.Client.FileImageIcon,
            //                    Name = grp.Key.Client.Name,
            //                    LastName = grp.Key.Client.LastName,
            //                    Telephone = grp.Key.Client.Telephone
            //                },
            //                Total = grp.Sum(s => s.Price),
            //                Comission = grp.Sum(s => s.Price)* (new Random()).Next(10,50)
            //            };

            //List<OrderDto> orders = 


            List<OrderDto> orders = _mapper.Map<List<OrderDto>>(_context.Orders
                                                            .Include(o => o.Client)
                                                            .Include(o => o.Trackings).ThenInclude(t => t.TrackingStatus)
                                                            .Include(o=> o.Trackings).ThenInclude(t=>t.TrackingProducts).ThenInclude(tp=>tp.Product)
                                                            .ToList());

            orders.ForEach(o=>
            {
                o.Trackings.ForEach(t =>
                {
                    o.Total += t.TrackingProducts.Sum(s => s.Product.Price);
                });
                o.Comission = o.Total * (new Random()).Next(10, 50);
            });

            return orders;
        }

        public OrderDto GetByOrderId(int orderId)
        {
            OrderDto order= _mapper.Map<OrderDto>(_context.Orders
                                                    .Include(o => o.Client)
                                                    .Include(o => o.Trackings).ThenInclude(t => t.TrackingStatus)
                                                    .Include(o => o.Trackings).ThenInclude(t => t.TrackingProducts).ThenInclude(tp => tp.Product)
                                                    .Where(w => w.OrderId == orderId).FirstOrDefault());
            order.Trackings.ForEach(t=>
            {
                order.Total += t.TrackingProducts.Sum(s => s.Product.Price);
            });

            order.Comission = order.Total * (new Random()).Next(10, 50);

            return order;
        }

        public OrderDto Update(OrderDto order)
        {
            Order orderUpdate = _context.Orders.Where(w => w.OrderId == order.OrderId).FirstOrDefault();
            orderUpdate = _mapper.Map<Order>(order);
            _context.Orders.Update(orderUpdate);
            _context.SaveChanges();

            return _mapper.Map<OrderDto>(orderUpdate);
        }

        public OrderDto Insert(OrderDto order)
        {
            Order orderCreate = new Order();
            orderCreate = _mapper.Map<Order>(order);
            _context.Orders.Add(orderCreate);
            _context.SaveChanges();

            return _mapper.Map<OrderDto>(orderCreate);
        }

        public OrderDto Delete(int orderId)
        {
            Order orderDelete = _context.Orders.Where(w => w.OrderId == orderId).FirstOrDefault();
            _context.Orders.Remove(orderDelete);
            _context.SaveChanges();

            return _mapper.Map<OrderDto>(orderDelete);
        }
    }
}
