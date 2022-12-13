import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterLink, RouterModule, Routes} from "@angular/router";
import { ClientFormComponent } from './components/client-form/client-form.component';
import { AdminFormComponent } from './components/admin-form/admin-form.component';

const routes: Routes = [
  {path: '', component: ClientFormComponent},
  {path: 'client-form', component: ClientFormComponent},
  {path: 'admin-form', component: AdminFormComponent},

];
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ClientFormComponent,
    AdminFormComponent
  ],
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule,
        FormsModule,
        RouterLink,
      RouterModule.forRoot(routes)
    ],
  exports:[
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
