import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {Location} from "../models/Location";

@Injectable({
  providedIn: 'root'
})
export class DataLocationsService {
  private readonly baseUrl = environment.baseUrl + "api/";
  constructor(private httpClient: HttpClient) { }

  public getLocations(): Observable<Location[]>{
    let route = "Locations/";
    return this.httpClient.get<Location[]>(this.baseUrl + route);
  }
}
