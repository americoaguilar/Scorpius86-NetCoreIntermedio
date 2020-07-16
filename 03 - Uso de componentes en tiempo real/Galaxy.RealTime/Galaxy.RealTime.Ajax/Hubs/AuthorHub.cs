using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.RealTime.NoSignalR.Hubs
{
    public class AuthorHub:Hub
    {
        public AuthorHub()
        {

        }

        public async Task RefreshAuthors()
        {
            await Clients.All.SendAsync("refreshAuthors",new { Id="setdtrd",Name="Erick"});
        }
    }
}
