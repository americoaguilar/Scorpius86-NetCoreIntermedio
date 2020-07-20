import { EventEmitter } from "@angular/core";
import { ProductModel } from "../../../models/product.model";
import * as signalR from "@microsoft/signalr";

export class ProductEvents {
  onNewProduct = new EventEmitter<ProductModel>();

  constructor(
    private _hubConnection: signalR.HubConnection
  ) {
    this._hubConnection.on('NewProduct', (product) => {
      this.onNewProduct.emit(product);
    });
  }
}
