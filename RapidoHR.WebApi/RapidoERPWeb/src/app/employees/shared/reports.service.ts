import { Injectable } from '@angular/core';
import { Reportemppayroll } from './reportemppayroll.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ReportsService {

  employeePayrollList : Reportemppayroll[];
  constructor(private http : Http) { }
  
  getReportEmployeePayroll()
  {
    
    return this.http.get('http://localhost:51504/api/ReportEmpPayroll')
    .map((data : Response)=>{
      return data.json() as Reportemppayroll[];
    }).toPromise().then(x=>{
           console.log(x.map(x=>x));
           debugger;
      this.employeePayrollList =x;
    })
    
  }

}
