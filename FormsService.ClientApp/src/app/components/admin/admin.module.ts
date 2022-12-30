import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import {AdministrateDishesComponent} from "./components/administrate/administrate-dishes/administrate-dishes.component";
import {AdministrateOrdersComponent} from "./components/administrate/administrate-orders/administrate-orders.component";
import {
  AdministratePersonsComponent
} from "./components/administrate/administrate-persons/administrate-persons.component";
import {AdminFormComponent} from "./components/admin-form/admin-form.component";
import {FormsModule} from "@angular/forms";
import { AdminHeaderComponent } from './components/admin-header/admin-header.component';


@NgModule({
  declarations: [
    AdministrateDishesComponent,
    AdministrateOrdersComponent,
    AdministratePersonsComponent,
    AdminFormComponent,
    AdminHeaderComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,

  ]
})
export class AdminModule { }
