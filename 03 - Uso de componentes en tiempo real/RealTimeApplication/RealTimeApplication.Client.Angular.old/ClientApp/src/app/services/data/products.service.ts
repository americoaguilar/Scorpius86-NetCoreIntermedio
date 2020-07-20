import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductModel } from "../../models/product.model";

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  productsURL = 'https://localhost:44342/api/Products';

  constructor(private httpClient: HttpClient) { }

  public list(): Observable<ProductModel[]> {
    return this.httpClient.get<ProductModel[]>(`${this.productsURL}/`);
  }
  public getByClientId(productId: number): Observable<ProductModel> {
    let params = new HttpParams();
    params = params.append('productId', productId.toString());
    return this.httpClient.get<ProductModel>(`${this.productsURL}/`, { params: params });
  }
}
