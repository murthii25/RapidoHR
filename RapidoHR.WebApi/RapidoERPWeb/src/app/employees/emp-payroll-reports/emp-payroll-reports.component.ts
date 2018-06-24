import { Component, OnInit } from '@angular/core';
import  { ReportsService } from '../shared/reports.service';

@Component({
  selector: 'app-emp-payroll-reports',
  templateUrl: './emp-payroll-reports.component.html',
  styleUrls: ['./emp-payroll-reports.component.css'],
  providers : [ReportsService]
})
export class EmpPayrollReportsComponent implements OnInit {

  constructor(private reportsService : ReportsService) { }

  ngOnInit() {
    debugger;
    this.reportsService.getReportEmployeePayroll().subscribe((data)=>{   
      debugger;  
      
        this.reportsService.selectedEmpPayrollReport = data.ReportEmpPayRollModel; 
  })
}

}
