import { Injectable } from '@angular/core';
import { Reportemppayroll } from './reportemppayroll.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class ReportsService {

  employeePayrollList : Reportemppayroll[];
  constructor(private http : Http) { }
  
  getReportEmployeePayroll()
  {
    
    return this.http.get('http://localhost:80/api/ReportEmpPayroll')
    .map((data : Response)=>{
      return data.json() as Reportemppayroll[];
    }).toPromise().then(x=>{                 
      this.employeePayrollList =x;
    }) .catch(this.handleError);    
  }
  handleError(error: Response)
  {
    debugger;
    console.log(error.text());
    return Observable.throw(error);
  }

}
