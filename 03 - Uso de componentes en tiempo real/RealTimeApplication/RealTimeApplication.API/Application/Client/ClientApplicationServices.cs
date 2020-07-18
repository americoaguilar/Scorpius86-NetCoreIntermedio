using RealTimeApplication.API.Infrastructure.Data.Repositories.Order;
using RealTimeApplication.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeApplication.API.Application.Order
{
    public class ClientApplicationServices : IClientApplicationServices
    {
        private readonly IClientRepository _clientRepository;

        public ClientApplicationServices(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ClientDto> List()
        {
            return _clientRepository.List();
        }

        public ClientDto GetByClientId(int clientId)
        {
            return _clientRepository.GetByClientId(clientId);
        }
        public ClientDto Update(int clientId, ClientDto client)
        {
            client.ClientId = clientId;
            return _clientRepository.Update(client);
        }

        public ClientDto Insert(ClientDto client)
        {
            return _clientRepository.Insert(client);
        }
        public ClientDto Delete(int clientId)
        {
            return _clientRepository.Delete(clientId);
        }
    }
}
