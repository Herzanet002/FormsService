import {Component, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {DataService} from "../../services/data.service";
import {Person} from "../../models/Person";

@Component({
  selector: 'app-admin-form',
  templateUrl: './admin-form.component.html',
  styleUrls: ['./admin-form.component.css']
})
export class AdminFormComponent implements OnInit {

  persons: Person[];
  @ViewChild('readOnlyTemplate', {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild('editTemplate', {static: false}) editTemplate: TemplateRef<any>|undefined;
  editedUser: Person|null = null;
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
    return this.editedUser && this.editedUser.id === person.id? this.editTemplate: this.readOnlyTemplate;
  }
  savePerson() {
    if (this.isNewRecord) {
      // добавляем пользователя
      this.dataService.createPerson(this.editedUser as Person).subscribe(_ => {
        this.statusMessage = 'Данные успешно добавлены',
          this.getPersons();
      });
      this.isNewRecord = false;
      this.editedUser = null;
    } else {
      // изменяем пользователя
      this.dataService.updatePerson(this.editedUser as Person).subscribe(_ => {
        this.statusMessage = 'Данные успешно обновлены',
          this.getPersons();
      });
      this.editedUser = null;
    }
  }

  public addPerson() {
    this.editedUser = {
      id:0,
      name:""
    };
    this.persons.push(this.editedUser);
    this.isNewRecord = true;
  }
  public editPerson(person: Person) {
    this.editedUser={
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
    this.editedUser = null;
  }
  ngOnInit(): void {
    this.getPersons();
  }


}
