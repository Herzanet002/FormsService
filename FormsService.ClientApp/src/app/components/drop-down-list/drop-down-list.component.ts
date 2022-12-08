import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-drop-down-list',
  templateUrl: './drop-down-list.component.html',
  styleUrls: ['./drop-down-list.component.css']
})
export class DropDownListComponent {
  // @ts-ignore
  @Input() listCollection: Array<string>;
  // @ts-ignore
  @Input() header: string;
}
