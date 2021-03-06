import { Component, OnInit } from '@angular/core';
import  { PayrollService } from '../shared/payroll.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-emp-payroll',
  templateUrl: './emp-payroll.component.html',
  styleUrls: ['./emp-payroll.component.css'],
  providers : [PayrollService]
})
export class EmpPayrollComponent implements OnInit {

  constructor(private payrollService : PayrollService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form? : NgForm)
  {
    if (form != null)
    form.reset();
    this.payrollService.selectedEmpPayroll = {
      EmpPRID: null,
      EmpID : null,
      basic: null,
      DA: null,
      HRA: null,
      conveyance: null,
      Adhoc_allow: null,
      PF_by_bank: null,
      PF_by_emp: null,
      Professional_tax: null,
      Festival_advance: null,
      HG_Insurance: null,
      LIC:null,
      Net_Pay: null,
      Date_created: null,
      Createdby: ''
    }

  }
  onSubmit(form : NgForm)
  {    
    if(form.value.EmpPRID === '00000000-0000-0000-0000-000000000000')
    {
          this.payrollService.PostEmpPayroll(form.value)
          .subscribe(data => {
                  this.resetForm(form);                 
                    })
    }
    else{     
      this.payrollService.PutEmpPayroll(form.value.EmpPRID,form.value)
      .subscribe(data => {
              this.resetForm(form);              
                })
    }
  }
  getEmpPayroll(empCode : string)
  {    
    this.payrollService.getEmployeePayroll(empCode).subscribe((data)=>{      
      this.resetForm();
        this.payrollService.selectedEmpPayroll = Object.assign({}, data.empPayrollModel);        
  });   
  }

}
