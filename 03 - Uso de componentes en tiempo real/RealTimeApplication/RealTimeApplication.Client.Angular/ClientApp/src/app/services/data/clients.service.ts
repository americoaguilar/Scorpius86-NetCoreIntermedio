import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import {ClientModel} from "../../models/client.model";

@Injectable({
  providedIn: 'root'
})
export class ClientsService {
  clientsURL = 'https://localhost:44342/api/Clients';

  constructor(private httpClient: HttpClient) { }

  public list(): Observable<ClientModel[]> {
    return this.httpClient.get<ClientModel[]>(`${this.clientsURL}/`);
  }
  public getByClientId(clientId:number): Observable<ClientModel> {
    let params = new HttpParams();
    params = params.append('clientId', clientId.toString());
    return this.httpClient.get<ClientModel>(`${this.clientsURL}/`, { params: params });
  }
}
