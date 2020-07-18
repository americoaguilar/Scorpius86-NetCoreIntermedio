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
    public class ClientRepository : IClientRepository
    {
        private readonly RealtimeapplicationContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(RealtimeapplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ClientDto> List()
        {
            var quey = from c in _context.Clients
                       join o in _context.Orders on c.ClientId equals o.ClientId
                       join t in _context.Trackings on o.OrderId equals t.OrderId
                       join tp in _context.TrackingProducts on t.TrackingId equals tp.TrackingId
                       join p in _context.Products on tp.ProductId equals p.ProductId
                       group p by new {c.ClientId,c.Name,c.LastName,c.Telephone,c.FileImageIcon } into grp
                       select new ClientDto
                       {
                           ClientId = grp.Key.ClientId,
                           Name = grp.Key.Name,
                           LastName = grp.Key.LastName,
                           Telephone = grp.Key.Telephone,
                           FileImageIcon = grp.Key.FileImageIcon,
                           Paid = grp.Sum(s => s.Price)
                       };

            List<ClientDto> clients = quey.ToList();
            clients.ForEach(c => c.AveragePercentage = (new Random()).Next(-100, 100));
            return clients;
        }

        public ClientDto GetByClientId(int clientId)
        {
            var quey = from c in _context.Clients
                       join o in _context.Orders on c.ClientId equals o.ClientId
                       join t in _context.Trackings on o.OrderId equals t.OrderId
                       join tp in _context.TrackingProducts on t.TrackingId equals tp.TrackingId
                       join p in _context.Products on tp.ProductId equals p.ProductId
                       where c.ClientId == clientId
                       group p by new { c.ClientId, c.Name, c.LastName, c.Telephone, c.FileImageIcon } into grp
                       select new ClientDto
                       {
                           ClientId = grp.Key.ClientId,
                           Name = grp.Key.Name,
                           LastName = grp.Key.LastName,
                           Telephone = grp.Key.Telephone,
                           FileImageIcon = grp.Key.FileImageIcon,
                           Paid = grp.Sum(s => s.Price)
                       };

            ClientDto clients = quey.FirstOrDefault();
            clients.AveragePercentage = (new Random()).Next(-100, 100);
            return clients;
        }

        public ClientDto Update(ClientDto client)
        {
            Client clientUpdate = _context.Clients.Where(w => w.ClientId == client.ClientId).FirstOrDefault();
            clientUpdate = _mapper.Map<Client>(client);
            _context.Clients.Update(clientUpdate);
            _context.SaveChanges();

            return _mapper.Map<ClientDto>(clientUpdate);
        }

        public ClientDto Insert(ClientDto client)
        {
            Client clientCreate = new Client();
            clientCreate = _mapper.Map<Client>(client);
            _context.Clients.Add(clientCreate);
            _context.SaveChanges();

            return _mapper.Map<ClientDto>(clientCreate);
        }

        public ClientDto Delete(int clientId)
        {
            Client clientDelete = _context.Clients.Where(w => w.ClientId == clientId).FirstOrDefault();
            _context.Clients.Remove(clientDelete);
            _context.SaveChanges();

            return _mapper.Map<ClientDto>(clientDelete);
        }
    }
}
