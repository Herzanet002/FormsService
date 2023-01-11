import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {Person} from "../../models/Person";
import {CategoryResponse} from "../../models/CategoryResponse";
import {Location} from "../../models/Location";
import {DataPersonsService} from "../../services/data-persons.service";
import {DataDishesService} from "../../services/data-dishes.service";

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit, OnChanges {
  constructor(private dataPersonsService: DataPersonsService,
              private dataDishesService: DataDishesService,
              private formBuilder: FormBuilder) {
  }
  clientForm: FormGroup
  personsSource: Array<Person> = [];
  dishesSource: CategoryResponse[] = [];
  locationsSource = [
    {id : 0, name : "В кафе"},
    {id : 1, name : "Возьму с собой"}
  ];
  ngOnChanges(changes: SimpleChanges): void {

  }

  public onSubmitForm(form: FormGroup){
    console.log(form);
  }

  private createForm(){
    this.clientForm = this.formBuilder.group(
      {
        person: ['', [Validators.required]],
        location:['',[Validators.required]],
        dishes: this.formBuilder.array([])
      });
  }

  get dishes() : FormArray {
    return <FormArray>this.clientForm.controls["dishes"];
  }


  private addDishControls(source: CategoryResponse[]){
    for(let i = 0; i<source.length; i++){
      const dishGroup = this.formBuilder.group({
        id: [''],
      });
      this.dishes.push(dishGroup);
    }
  }
  ngOnInit(): void {
    this.createForm();
    this.getPersons();
    this.getDishes();
  }

  private getPersons() {
    this.dataPersonsService.getPersons()
      .subscribe((data:Person[]) => {
        return this.personsSource = data;
      });
  }
  private getDishes() {
    this.dataDishesService.getDishesByCategory()
      .subscribe((data: CategoryResponse[]) => {
        this.addDishControls(data);
        console.log(data);
        return this.dishesSource = data;
      });
  }
}
