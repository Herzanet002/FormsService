import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Person} from "../models/Person";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DataPersonsService {
  private readonly baseUrl = environment.baseUrl + "api/";
  constructor(private httpClient: HttpClient) { }

  public getPersons(): Observable<Person[]> {
    let route = "Persons/";
    return this.httpClient.get<Person[]>(this.baseUrl + route);
  }
  public updatePerson(id:number, person: Person) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    let route = "Persons/";
    return this.httpClient.put<Person>(this.baseUrl + route + id, JSON.stringify(person), {headers: myHeaders});
  }

  public createPerson(person: Person) {
    let route = "Persons/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Person>(this.baseUrl + route, JSON.stringify(person), {headers: headers});
  }

  public deleteUser(id: number) {
    let route = "Persons/";
    return this.httpClient.delete<Person>(this.baseUrl + route + id);
  }
}
