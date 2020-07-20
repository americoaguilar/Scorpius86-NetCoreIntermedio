import { EventEmitter } from "@angular/core";
import * as signalR from "@microsoft/signalr";
import { OrderModel } from "../../../models/order.model";

export class OrderEvents {
  onNewOrder = new EventEmitter<OrderModel>();

  constructor(
    private _hubConnection: signalR.HubConnection
  ) {
    this._hubConnection.on('NewOrder', (order) => {
      this.onNewOrder.emit(order);
    });
  }
}
