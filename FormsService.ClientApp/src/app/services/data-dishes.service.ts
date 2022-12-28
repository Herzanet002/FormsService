import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {CategoryResponse} from "../models/CategoryResponse";
import {Dish} from "../models/Dish";

@Injectable({
  providedIn: 'root'
})
export class DataDishesService {
  private readonly port = "https://localhost:7234/api/"
  constructor(private httpClient: HttpClient) { }

  public getDishesByCategory(): Observable<CategoryResponse[]> {
    let route = "Dish/getByCategories/";
    return this.httpClient.get<CategoryResponse[]>(this.port + route);
  }

  public getDishes(): Observable<Dish[]> {
    let route = "Dish/getAll/";
    return this.httpClient.get<Dish[]>(this.port + route);
  }

  public deleteDish(id: number){
    let route = "Dish/delete/";
    return this.httpClient.delete<Dish>(this.port + route + id);
  }

  public updateDish(dish: Dish){
    let route = "Dish/update/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    console.log(JSON.stringify(dish));
    return this.httpClient.put<Dish>(this.port + route, JSON.stringify(dish), {headers: headers});
  }

  public createDish(dish: Dish) {
    let route = "Dish/create/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Dish>(this.port + route, JSON.stringify(dish), {headers: headers});

  }
}
