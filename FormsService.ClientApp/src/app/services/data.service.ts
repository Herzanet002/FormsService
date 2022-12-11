import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {List} from "postcss/lib/list";
import { Person } from '../models/Person';
import { Dish } from '../models/Dish';
import {Observable} from "rxjs";
import {CategoryResponse} from "../models/CategoryResponse";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  //TODO: API_URL
  private readonly port = "https://localhost:7234/"
  constructor(private httpClient: HttpClient) {

  }

  getEmployees(): Observable<Person[]>{
    let route = "api/Person/getAll/";
    return this.httpClient.get<Person[]>(this.port + route);
  }

  getDishes() : Observable<CategoryResponse[]>{
    let route = "api/Dish/getDishesByCategories/";
    return this.httpClient.get<CategoryResponse[]>(this.port + route);
  }


}
