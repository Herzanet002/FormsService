import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Person } from '../models/Person';
import {Observable} from "rxjs";
import {CategoryResponse} from "../models/CategoryResponse";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  //TODO: API_URL
  private readonly port = "https://localhost:7234/api/"
  constructor(private httpClient: HttpClient) {

  }

  public getEmployees(): Observable<Person[]>{
    let route = "Person/getAll/";
    return this.httpClient.get<Person[]>(this.port + route);
  }

  public getDishes() : Observable<CategoryResponse[]>{
    let route = "Dish/getDishesByCategories/";
    return this.httpClient.get<CategoryResponse[]>(this.port + route);
  }

  public updatePerson(person: Person) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    let route = "Person/updatePerson/";
    return this.httpClient.put<Person>(this.port + route, JSON.stringify(person), {headers:myHeaders});
  }
  public createPerson(person: Person){
    let route = "Person/createPerson/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Person>(this.port + route,JSON.stringify(person), {headers: headers});
  }

  public deleteUser(id: number){
    let route = "Person/deletePerson/";
    return this.httpClient.delete<Person>(this.port + route + id);
  }


}
