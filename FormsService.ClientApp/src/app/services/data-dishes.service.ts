import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {CategoryResponse} from "../models/CategoryResponse";
import {Dish} from "../models/Dish";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DataDishesService {
  private readonly baseUrl = environment.baseUrl + "api/";
  constructor(private httpClient: HttpClient) { }

  public getDishesByCategory(): Observable<CategoryResponse[]> {
    let route = "Dishes/getByCategories/";
    return this.httpClient.get<CategoryResponse[]>(this.baseUrl + route);
  }

  public getDishes(): Observable<Dish[]> {
    let route = "Dishes/";
    return this.httpClient.get<Dish[]>(this.baseUrl + route);
  }

  public deleteDish(id: number){
    let route = "Dishes/";
    return this.httpClient.delete<Dish>(this.baseUrl + route + id);
  }

  public updateDish(id:number, dish: Dish){
    let route = "Dishes/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    console.log(JSON.stringify(dish));
    return this.httpClient.put<Dish>(this.baseUrl + route + id, JSON.stringify(dish), {headers: headers});
  }

  public createDish(dish: Dish) {
    let route = "Dishes";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Dish>(this.baseUrl + route, JSON.stringify(dish), {headers: headers});

  }
}
