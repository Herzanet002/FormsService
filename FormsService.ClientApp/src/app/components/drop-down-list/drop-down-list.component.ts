import {Component, Input} from '@angular/core';
import {Person} from "../../models/Person";
import {NamedEntity} from "../../models/NamedEntity";

@Component({
  selector: 'app-drop-down-list',
  templateUrl: './drop-down-list.component.html',
  styleUrls: ['./drop-down-list.component.css']
})
export class DropDownListComponent {
  // @ts-ignore
  @Input() listCollection: Array<NamedEntity>;
  // @ts-ignore
  @Input() header: string;
}
