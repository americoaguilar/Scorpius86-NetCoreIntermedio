using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using RealTimeApplication.HUB.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealTimeApplication.Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override async void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            var orders = new ObservableCollection<UpdateInfoDto>();
            OrderList.ItemsSource = orders;

            var parameters = new Dictionary<string, string>
            {
                { "group", "allUpdates" }
            };

            //var hubConnection = new HubConnection("https://localhost:44340", queryStrings);
            //var hubProxy = hubConnection.CreateHubProxy("CoffeeHub");

            var hubConnection = new HubConnectionBuilder()
                //.WithUrl("https://localhost:44340/CoffeeHub")
                .WithUrl("http://realtimeapplication-hub.azurewebsites.net/coffeeHub")
                .Build();

            hubConnection.On<UpdateInfoDto>("ReceiveOrderUpdate", updateObject =>
            {
                var order = orders.SingleOrDefault(c => c.OrderId == updateObject.OrderId);
                if (order != null)
                    Dispatcher.Invoke(() => orders.Remove(order));

                if (!updateObject.IsFinished)
                    Dispatcher.Invoke(() => orders.Add(updateObject));
            });

            await hubConnection.StartAsync();

            await hubConnection.InvokeAsync("Connected", parameters);
        }
    }
}
