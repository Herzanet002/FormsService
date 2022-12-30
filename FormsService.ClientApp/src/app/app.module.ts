import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterLink, RouterModule, Routes} from "@angular/router";
import { ClientFormComponent } from './components/client-form/client-form.component';
import {DataPersonsService} from "./services/data-persons.service";
import {DataDishesService} from "./services/data-dishes.service";
import {DataOrdersService} from "./services/data-orders.service";
import {ToastrModule} from "ngx-toastr";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { NotFoundComponent } from './components/not-found/not-found.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {path: '', component: ClientFormComponent},
  {path: 'client-form', component: ClientFormComponent},
  {path: 'admin-form',
    loadChildren: ()=> import('./components/admin/admin.module').then((m => m.AdminModule))},
  {path:'login', component:LoginComponent},
  {path: '**', component: NotFoundComponent},

];
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ClientFormComponent,
    NotFoundComponent,
    LoginComponent
  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        FormsModule,
        RouterLink,
      RouterModule.forRoot(routes),
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
    ],
  exports:[
    RouterModule
  ],
  providers: [DataPersonsService, DataDishesService, DataOrdersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
