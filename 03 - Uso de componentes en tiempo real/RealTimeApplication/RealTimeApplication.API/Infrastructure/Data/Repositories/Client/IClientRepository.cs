using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Infrastructure.Data.Repositories.Order
{
    public interface IClientRepository
    {
        ClientDto Delete(int clientId);
        ClientDto GetByClientId(int clientId);
        ClientDto Insert(ClientDto client);
        List<ClientDto> List();
        ClientDto Update(ClientDto client);
    }
}