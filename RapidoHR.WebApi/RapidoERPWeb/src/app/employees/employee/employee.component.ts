import { Component, OnInit } from '@angular/core';
import  { EmployeeService } from '../shared/employee.service';
import { NgForm } from '@angular/forms';
import { AuthenticationService } from '../../shared/authentication.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers:[AuthenticationService]
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeService : EmployeeService,private _service:AuthenticationService) { }

  ngOnInit() {
    //this._service.checkCredentials();
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
      IsContract:false,
      DateCreated: '',
      Createdby: ''
    }

  }
  onSubmit(form : NgForm)
  {
    var myObj = JSON.parse(window.localStorage.getItem("user"));
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
