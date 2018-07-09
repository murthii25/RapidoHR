import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmpPayrollComponent } from './employees/emp-payroll/emp-payroll.component';
import { EmpPayrollReportsComponent } from './employees/emp-payroll-reports/emp-payroll-reports.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeeComponent,
    EmployeeListComponent,
    EmpPayrollComponent,
    EmpPayrollReportsComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      
    {
      path: '', component: LoginComponent 
    },
    {
      path:'Home', component : HomeComponent
    },
    {
      path : 'employee',
      component : EmployeesComponent
    },
    {
      path : 'payroll',
      component : EmpPayrollComponent
    },
    {
      path : 'payrollreports',
      component : EmpPayrollReportsComponent
    },
    {path:'**',redirectTo:''}

  ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
