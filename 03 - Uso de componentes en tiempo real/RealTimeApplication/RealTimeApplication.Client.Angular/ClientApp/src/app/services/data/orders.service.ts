import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import {OrderModel} from "../../models/order.model";

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  ordersURL = 'https://localhost:44342/api/orders';

  constructor(private httpClient: HttpClient) { }

  public list(): Observable<OrderModel[]> {
    return this.httpClient.get<OrderModel[]>(`${this.ordersURL}/`);
  }
  public getByOrderId(orderId:number): Observable<OrderModel> {
    let params = new HttpParams();
    params = params.append('orderId', orderId.toString());
    return this.httpClient.get<OrderModel>(`${this.ordersURL}/`, { params: params });
  }
}
