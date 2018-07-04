import { Component, OnInit } from '@angular/core';
import  { ReportsService } from '../shared/reports.service';
import { Reportemppayroll } from '../shared/reportemppayroll.model';

@Component({
  selector: 'app-emp-payroll-reports',
  templateUrl: './emp-payroll-reports.component.html',
  styleUrls: ['./emp-payroll-reports.component.css'],
  providers : [ReportsService]
})
export class EmpPayrollReportsComponent implements OnInit {

  constructor(private reportsService : ReportsService) { }

  ngOnInit() {       
    this.reportsService.getReportEmployeePayroll();
}

}
