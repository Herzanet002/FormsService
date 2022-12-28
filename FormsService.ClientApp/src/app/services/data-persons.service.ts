import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Person} from "../models/Person";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DataPersonsService {
  private readonly port = "https://localhost:7234/api/"
  constructor(private httpClient: HttpClient) { }

  public getPersons(): Observable<Person[]> {
    let route = "Person/getAll/";
    return this.httpClient.get<Person[]>(this.port + route);
  }
  public updatePerson(person: Person) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    let route = "Person/update/";
    return this.httpClient.put<Person>(this.port + route, JSON.stringify(person), {headers: myHeaders});
  }

  public createPerson(person: Person) {
    let route = "Person/create/";
    const headers = new HttpHeaders().set("Content-Type", "application/json");
    return this.httpClient.post<Person>(this.port + route, JSON.stringify(person), {headers: headers});
  }

  public deleteUser(id: number) {
    let route = "Person/delete/";
    return this.httpClient.delete<Person>(this.port + route + id);
  }
}
