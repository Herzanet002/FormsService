import {Component, OnInit} from '@angular/core';
import {DataService} from "../../services/data.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {Person} from "../../models/Person";
import {CategoryResponse} from "../../models/CategoryResponse";
import {Location} from "../../models/Location";

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit{
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
