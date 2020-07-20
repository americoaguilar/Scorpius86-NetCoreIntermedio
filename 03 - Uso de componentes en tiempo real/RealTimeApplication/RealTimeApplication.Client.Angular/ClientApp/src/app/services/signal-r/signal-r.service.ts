import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { OrderModel } from '../../models/order.model';
import { ClientModel } from '../../models/client.model';
import { TrackingModel } from '../../models/tracking.model';
import { ProductModel } from '../../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  connectionEstablished = new EventEmitter<boolean>();

  onNewOrder = new EventEmitter<OrderModel>();
  onNewClient = new EventEmitter<ClientModel>();
  onNewTracking = new EventEmitter<TrackingModel>();
  onUpdateTracking = new EventEmitter<TrackingModel>();
  onNewProduct = new EventEmitter<ProductModel>();

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
    this._hubConnection.on('NewOrder', (order) => {
      this.onNewOrder.emit(order);
    });
    this._hubConnection.on('NewClient', (client) => {
      this.onNewClient.emit(client);
    });
    this._hubConnection.on('NewTracking', (tracking) => {
      this.onNewTracking.emit(tracking);
    });
    this._hubConnection.on('UpdateTracking', (tracking) => {
      this.onUpdateTracking.emit(tracking);
    });
    this._hubConnection.on('NewProduct', (product) => {
      this.onNewProduct.emit(product);
    });
  }
}
