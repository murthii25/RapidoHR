import { Component, OnInit } from '@angular/core';
import  { EmployeeService } from '../shared/employee.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeService : EmployeeService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form? : NgForm)
  {
    if (form != null)
    form.reset();
    this.employeeService.selectedEmployee = {
      EmpID : null,
      EmpCode: '',
      FirstName:  '',
      MiddleName: '',
      LastName:  '',
      Gender:  '',
      Nationality: '',
      Designation: '',
      Address:  '',
      EmailId:  '',
      ContactNo: null,
      DateCreated: '',
      Createdby: ''
    }

  }
  onSubmit(form : NgForm)
  {
    if(form.value.EmpID == null)
    {
          this.employeeService.PostEmployee(form.value)
          .subscribe(data => {
                  this.resetForm(form);
                  this.employeeService.getEmployeeList();
                    })
    }
    else{     
      this.employeeService.PutEmployee(form.value.EmpID,form.value)
      .subscribe(data => {
              this.resetForm(form);
              this.employeeService.getEmployeeList();
                })
    }
  }

}
