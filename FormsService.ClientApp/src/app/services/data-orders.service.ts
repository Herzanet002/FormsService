import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import { Order } from '../models/Order';
import {environment} from "../../environments/environment";
import {DatesRange} from "../models/DatesRange";

@Injectable({
  providedIn: 'root'
})
export class DataOrdersService {
  private readonly baseUrl = environment.baseUrl + "api/";
  constructor(private httpClient: HttpClient) { }

  public getOrders(): Observable<Order[]> {
    let route = "Orders/";
    return this.httpClient.get<Order[]>(this.baseUrl + route);
  }
  public updateOrder(id:number, order: Order) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    let route = "Orders/";
    return this.httpClient.put<Order>(this.baseUrl + route + id, JSON.stringify(order), {headers: myHeaders});
  }

  public getDatesRange(){
    let route = "Orders/get-dates";
    return this.httpClient.get<DatesRange>(this.baseUrl + route);
  }
  public createOrder(order: Order) {
    let route = "Orders/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Order>(this.baseUrl + route, JSON.stringify(order), {headers: headers});
  }

  public deleteOrder(id: number) {
    let route = "Orders/";
    return this.httpClient.delete<Order>(this.baseUrl + route + id);
  }
}
