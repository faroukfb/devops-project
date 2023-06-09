import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AddEmployeeComponent } from './component/employees/add-employee/add-employee.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesListComponent } from './component/employees/employees-list/employees-list.component';
import { FormsModule } from '@angular/forms';

import { EditEmployeeComponent } from './component/employees/edit-employee/edit-employee.component';

@NgModule({
  declarations: [
   AppComponent,
   EmployeesListComponent,
   AddEmployeeComponent,
 
   EditEmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
