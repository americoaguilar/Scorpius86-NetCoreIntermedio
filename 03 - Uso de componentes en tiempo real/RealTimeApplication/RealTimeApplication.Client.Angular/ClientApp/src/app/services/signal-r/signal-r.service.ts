import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { ClientEvents } from './events/client.events';
import { OrderEvents } from './events/order.events';
import { ProductEvents } from './events/product.events';
import { TrackingEvents } from './events/tracking.events';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  connectionEstablished = new EventEmitter<boolean>();
  ClientEvents: ClientEvents;
  OrderEvents: OrderEvents;
  Productevents: ProductEvents;
  TrackingEvents: TrackingEvents;

  private connectionIsEstablished = false;
  private _hubConnection: signalR.HubConnection;

  constructor() {
    this.createConnection();
    this.registerClientEvents();
    this.startConnection();
  }

  private createConnection() {
    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44340/OrderHub')
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function () { this.startConnection(); }, 5000);
      });
  }

  private registerClientEvents(): void {
    this.ClientEvents = new ClientEvents(this._hubConnection);
    this.OrderEvents = new OrderEvents(this._hubConnection);
    this.Productevents = new ProductEvents(this._hubConnection);
    this.TrackingEvents = new TrackingEvents(this._hubConnection);
  }
}
