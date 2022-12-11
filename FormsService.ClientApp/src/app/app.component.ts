import {Component, OnInit} from '@angular/core';
import {DataService} from "./services/data.service";
import {Person} from "./models/Person";
import { Dish } from './models/Dish';
import {Location} from "./models/Location";
import {LocationEnums} from "./models/LocationEnums";
import {FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, Validators} from "@angular/forms";
import {CategoryResponse} from "./models/CategoryResponse";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[DataService]
})
export class AppComponent implements OnInit{
  dates = '06.12-12.12'
  constructor(private dataService: DataService, private formBuilder: FormBuilder) {
  }
  clientForm: FormGroup
  personsSource: Array<Person> = [];
  dishesSource: CategoryResponse[] = [];
  locationsSource = new Array<Location>({name:"В кафе"}, {name:"Заберу с собой"});
  public onSubmitForm(form: FormGroup){
    console.log(form);
  }

  private createForm(){
    this.clientForm = this.formBuilder.group(
      {
        person: ['', [Validators.required]],
        location:['',[Validators.required]],
      });
  }

  private addDishControls(source: CategoryResponse[]){
    for(let i = 0; i<source.length; i++){
      this.clientForm.addControl(`dish${i+1}`, new FormControl(''));
    }
  }
  ngOnInit(): void {
    this.createForm();
    this.getPersons();
    this.getDishes();
  }

  private getPersons() {
    this.dataService.getEmployees()
      .subscribe((data:Person[]) => {

        return this.personsSource = data;
      });
  }
  private getDishes() {
    this.dataService.getDishes()
      .subscribe((data: CategoryResponse[]) => {
        this.addDishControls(data);
        console.log(data);
        return this.dishesSource = data;
      });
  }




}
