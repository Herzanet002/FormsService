import {Component, OnInit} from '@angular/core';
import {DataService} from "./services/data.service";
import {Person} from "./models/Person";
import { Dish } from './models/Dish';
import {Location} from "./models/Location";
import {LocationEnums} from "./models/LocationEnums";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[DataService]
})
export class AppComponent implements OnInit{
  dates = '06.12-12.12'
  constructor(private dataService: DataService) {
  }

  persons: Array<Person> = [];
  dishes: Array<Dish> = [];
  soups: Array<Dish> = [];
  firstCourses: Array<Dish> = [];

  ngOnInit(): void {
    this.loadPersons();
    this.loadSalads();
  }

  loadPersons() {
    this.dataService.getEmployees()
      .subscribe((data:any) => {
        return this.persons = data;
      });
  }
  loadSalads() {
    this.dataService.getDishes()
      .subscribe((data:any) => {
        return this.dishes = data;
      });
  }




  categories = LocationEnums;
  locations = new Array<Location>({name:"В кафе"}, {name:"Заберу с собой"});



}
