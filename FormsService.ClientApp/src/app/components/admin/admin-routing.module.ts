import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AdminFormComponent} from "./components/admin-form/admin-form.component";
import {AdministrateDishesComponent} from "./components/administrate/administrate-dishes/administrate-dishes.component";
import {AdministrateOrdersComponent} from "./components/administrate/administrate-orders/administrate-orders.component";
import {
  AdministratePersonsComponent
} from "./components/administrate/administrate-persons/administrate-persons.component";
import {
  AdministrateDashboardComponent
} from "./components/administrate/administrate-dashboard/administrate-dashboard.component";

const routes: Routes = [
  {path:'', component: AdminFormComponent,
    children:[
      {path: "dashboard", component:AdministrateDashboardComponent},
      {path: "dishes", component: AdministrateDishesComponent},
      {path: "orders", component: AdministrateOrdersComponent},
      {path: "persons", component: AdministratePersonsComponent},
      {path:"", component:AdministrateDashboardComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
