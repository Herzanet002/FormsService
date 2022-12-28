import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import { Order } from '../models/Order';

@Injectable({
  providedIn: 'root'
})
export class DataOrdersService {
  private readonly port = "https://localhost:7234/api/"
  constructor(private httpClient: HttpClient) { }

  public getOrders(): Observable<Order[]> {
    let route = "Order/getAll/";
    return this.httpClient.get<Order[]>(this.port + route);
  }
  public updateOrder(order: Order) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    let route = "Order/update/";
    return this.httpClient.put<Order>(this.port + route, JSON.stringify(order), {headers: myHeaders});
  }

  public createOrder(order: Order) {
    let route = "Order/create/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Order>(this.port + route, JSON.stringify(order), {headers: headers});
  }

  public deleteOrder(id: number) {
    let route = "Order/delete/";
    return this.httpClient.delete<Order>(this.port + route + id);
  }
}
