import { EventEmitter } from "@angular/core";
import { ClientModel } from "../../../models/client.model";
import * as signalR from "@microsoft/signalr";

export class ClientEvents {
  onNewClient = new EventEmitter<ClientModel>();

  constructor(
    private _hubConnection: signalR.HubConnection
  ) {
    this._hubConnection.on('NewClient', (client) => {
      this.onNewClient.emit(client);
    });
  }
}
