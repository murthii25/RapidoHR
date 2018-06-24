import { Injectable } from '@angular/core';
import { Reportemppayroll } from './reportemppayroll.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ReportsService {

  selectedEmpPayrollReport : Reportemppayroll;
  constructor(private http : Http) { }
  
  getReportEmployeePayroll()
  {
    debugger;
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Get, headers : headerOptions});
    return this.http.get('http://localhost:51504/api/ReportEmpPayroll',requestOptions).map(res=>res.json());   
  }

}
