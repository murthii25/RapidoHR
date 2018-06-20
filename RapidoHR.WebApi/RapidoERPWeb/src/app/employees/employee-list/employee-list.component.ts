import { Component, OnInit } from '@angular/core';

import  { EmployeeService } from '../shared/employee.service';
import { Employee } from '../shared/employee.model';
import { Guid } from "guid-typescript";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private employeeService : EmployeeService) { }

  ngOnInit() {    
    this.employeeService.getEmployeeList();
  }

  showForEdit(emp : Employee)
  {
    this.employeeService.selectedEmployee = Object.assign({}, emp);
  }
  onDeleteEmployee(empId : Guid)
  {
    if(confirm('Are you sure to delete employee') == true)
    {
      this.employeeService.deleteEmployee(empId).subscribe(x=> { this.employeeService.getEmployeeList();
      })
    }
  }
}
