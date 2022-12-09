import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {List} from "postcss/lib/list";
import { Person } from '../models/Person';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  //TODO: API_URL
  private readonly port = "https://localhost:7234"
  constructor(private httpClient: HttpClient) {

  }

  getEmployees(){
    let route = "/api/Person/getAll/";
    return this.httpClient.get(this.port + route);
  }

  getDishes(){
    let route = "/api/Dish/getAll/";
    return this.httpClient.get(this.port + route);
  }


}
