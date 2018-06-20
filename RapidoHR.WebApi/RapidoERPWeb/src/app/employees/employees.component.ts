import { Component, OnInit } from '@angular/core';
import  { EmployeeService } from './shared/employee.service';
import  { PayrollService } from './shared/payroll.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers : [EmployeeService, PayrollService]
})
export class EmployeesComponent implements OnInit {

  constructor(private employeeService : EmployeeService ,private payrollService: PayrollService) { }

  ngOnInit() {
    
  }  
  

}
