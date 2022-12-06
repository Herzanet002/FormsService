import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FormsService.ClientApp';
  dates = '06.12-12.12'
  employees : Array<string> = new Array<string>("Сотрудник 1",
    "Сотрудник 2",
    "Сотрудник 3",
    "Сотрудник 4",
    "Сотрудник 5",
    "Сотрудник 6",
    "Сотрудник 7",
    "Сотрудник 8");

  locations: Array<string> = new Array<string>("В кафе", "Заберу с собой");

  salads: Array<string> = new Array<string>("Салат 1", "Салат 2", "Салат 3");
  soups: Array<string> = new Array<string>("Суп 1", "Суп 2", "Суп 3");
  firstCourses: Array<string> = new Array<string>("Горячее 1", "Горячее 2", "Горячее 3");

}
