import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {DishCategory} from "../models/DishCategory";

@Injectable({
  providedIn: 'root'
})
export class DataCategoriesService {
  private readonly baseUrl = environment.baseUrl + "api/";
  constructor(private httpClient: HttpClient) { }

  public getCategories(): Observable<DishCategory[]> {
    let route = "Categories/";
    return this.httpClient.get<DishCategory[]>(this.baseUrl + route);
  }
}
