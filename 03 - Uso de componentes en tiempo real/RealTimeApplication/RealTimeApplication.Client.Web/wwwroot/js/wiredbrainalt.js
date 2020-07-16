//WebSocket = undefined;
//EventSource = undefined;

setupConnection = (connection) => {

    connection.on("ReceiveOrderUpdate", function (updateObject) {
        const statusDiv = document.getElementById("status");
        statusDiv.innerHTML = `Order: ${updateObject.OrderId}: ${updateObject.Update}`;
    });

    connection.on("NewOrder", function (order) {
        const statusDiv = document.getElementById("status");
        statusDiv.innerHTML = `Somebody ordered an ${order.Product}`;
    });
};

document.addEventListener("DOMContentLoaded", function (event) {
    const connection = new signalR.HubConnectionBuilder()
        //.withUrl("https://localhost:44340/coffeeHub", { transport: signalR.HttpTransportType.LongPolling})
        //.withUrl("https://localhost:44340/coffeeHub")
        .withUrl("http://realtimeapplication-hub.azurewebsites.net/coffeeHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    setupConnection(connection);
    connection.start();
   
    document.getElementById("submit").addEventListener("click",
        e => {
            e.preventDefault();
            var statusDiv = document.getElementById("status");
            statusDiv.innerHTML = "Submitting order..";

            const product = document.getElementById("product").value;
            const size = document.getElementById("size").value;
            var urlAPI = "https://realtimeapplication-api.azurewebsites.net/api/Coffee";
            //var urlAPI = "https://localhost:44342/api/Coffee";
            fetch(urlAPI,
                {
                    method: "POST",
                    body: JSON.stringify({ product, size }),
                    headers: {
                        'content-type': 'application/json'
                    }
                })
                .then(response => response.text())
                .then(id => {
                    let order = {
                        orderId: parseInt(id),
                        product: product,
                        size: size
                    };
                    //order = JSON.stringify(order);
                    connection.invoke('GetUpdateForOrder', order)
                    .catch(function (err) {
                        return console.error(err.toString());
                    });
                })
                
        });
});
