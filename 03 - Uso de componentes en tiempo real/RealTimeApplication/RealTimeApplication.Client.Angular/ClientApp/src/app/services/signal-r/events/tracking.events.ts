import { TrackingModel } from "../../../models/tracking.model";
import { EventEmitter } from "@angular/core";
import * as signalR from "@microsoft/signalr";

export class TrackingEvents {
  onNewTracking = new EventEmitter<TrackingModel>();
  onUpdateTracking = new EventEmitter<TrackingModel>();
  onDeleteTracking = new EventEmitter<TrackingModel>();

  constructor(
    private _hubConnection: signalR.HubConnection
  ) {

    this._hubConnection.on('NewTracking', (tracking) => {
      this.onNewTracking.emit(tracking);
    });
    this._hubConnection.on('UpdateTracking', (tracking) => {
      this.onUpdateTracking.emit(tracking);
    });
    this._hubConnection.on('DeleteTracking', (tracking) => {
      this.onDeleteTracking.emit(tracking);
    });

  }
}
