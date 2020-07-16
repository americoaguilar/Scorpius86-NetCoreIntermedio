using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galaxy.RealTime.NoSignalR.Models;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Galaxy.RealTime.NoSignalR.Hubs;

namespace Galaxy.RealTime.NoSignalR.Controllers
{
    public class HomeController : Controller
    {
        public IHubContext<AuthorHub> _authorHub { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHubContext<AuthorHub> authorHub, IHttpContextAccessor httpContextAccessor)
        {
            _authorHub = authorHub;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ajax()
        {
            return View();
        }

        public IActionResult Poll()
        {
            return View();
        }

        public IActionResult LongPoll()
        {
            return View();
        }
        public IActionResult ServerSentEvents()
        {
            return View();
        }

        public IActionResult WebSocket()
        {
            return View();
        }

        public IActionResult SignalR()
        {
            return View();
        }

        public async Task<IActionResult> RefreshAuthors()
        {
            await _authorHub.Clients.All.SendAsync("refreshAuthors");
            return Accepted(1);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async void ServerNotification()
        {
            Response.ContentType = "text/event-stream";
   
            await HttpContext.Response.WriteAsync("datos", CancellationToken.None);
            await HttpContext.Response.Body.FlushAsync();

            Response.Body.Close();
        }

        public async void WebSocketNotification()
        {
            var context = _httpContextAccessor.HttpContext;
            if (context.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await SendEvents(webSocket, "test");
                await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                    "Done", CancellationToken.None);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }

        private async Task SendEvents(WebSocket webSocket, string data)
        {

                Thread.Sleep(2000);
                var jsonMessage = $"\"{data}\"";
                await webSocket.SendAsync(buffer: new ArraySegment<byte>(
                    array: Encoding.ASCII.GetBytes(jsonMessage),
                    offset: 0,
                    count: jsonMessage.Length),
                    messageType: WebSocketMessageType.Text,
                    endOfMessage: true,
                    cancellationToken: CancellationToken.None
                );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
