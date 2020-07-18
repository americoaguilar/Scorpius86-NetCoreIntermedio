using RealTimeApplication.Infrastructure.Dtos;
using System.Collections.Generic;

namespace RealTimeApplication.API.Application.Order
{
    public interface IClientApplicationServices
    {
        ClientDto Delete(int clientId);
        ClientDto GetByClientId(int clientId);
        ClientDto Insert(ClientDto client);
        List<ClientDto> List();
        ClientDto Update(int clientId, ClientDto client);
    }
}