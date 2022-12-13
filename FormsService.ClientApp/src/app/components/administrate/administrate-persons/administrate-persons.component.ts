import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {Person} from "../../../models/Person";
import {DataService} from "../../../services/data.service";

@Component({
  selector: 'app-administrate-persons',
  templateUrl: './administrate-persons.component.html',
  styleUrls: ['./administrate-persons.component.css']
})
export class AdministratePersonsComponent implements OnInit{
  persons: Person[];
  @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;
  editedPerson: Person|null = null;
  isNewRecord: boolean = false;
  statusMessage: string = "";
  constructor(private dataService: DataService) {
    this.persons = new Array<Person>();
  }

  private getPersons(){
    this.dataService.getEmployees().subscribe((data:Person[]) => {
      return this.persons = data});
  }

  public loadTemplate(person: Person) {
    return this.editedPerson && this.editedPerson.id === person.id? this.editTemplate: this.readOnlyTemplate;
  }
  savePerson() {
    if (this.isNewRecord) {
      // добавляем пользователя
      this.dataService.createPerson(this.editedPerson as Person).subscribe(_ => {
        this.statusMessage = 'Данные успешно добавлены',
          this.getPersons();
      });
      this.isNewRecord = false;
      this.editedPerson = null;
    } else {
      // изменяем пользователя
      this.dataService.updatePerson(this.editedPerson as Person).subscribe(_ => {
        this.statusMessage = 'Данные успешно обновлены',
          this.getPersons();
      });
      this.editedPerson = null;
    }
  }

  public addPerson() {
    this.editedPerson = {
      id:0,
      name:""
    };
    this.persons.push(this.editedPerson);
    this.isNewRecord = true;
  }
  public editPerson(person: Person) {
    this.editedPerson={
      id: person.id,
      name: person.name
    }
  }

  public deletePerson(person: Person) {
    this.dataService.deleteUser(person.id).subscribe(_ => {
      this.statusMessage = 'Данные успешно удалены',
        this.getPersons();
    });
  }
  cancel() {
    // если отмена при добавлении, удаляем последнюю запись
    if (this.isNewRecord) {
      this.persons.pop();
      this.isNewRecord = false;
    }
    this.editedPerson = null;
  }
  ngOnInit(): void {
    this.getPersons();
  }

}
