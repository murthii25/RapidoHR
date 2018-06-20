import { Injectable } from '@angular/core';
import { Payroll } from './payroll.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Guid } from "guid-typescript";

@Injectable()
export class PayrollService {

  selectedEmpPayroll : Payroll;
  constructor(private http : Http) { }
  
  getEmployeePayroll(empcode : string)
  {
    debugger;
    this.http.get('http://localhost:51504/api/EmpCodePayroll/' + empcode)
    .map((data : Response)=>{
      debugger;
      return data.json() as Payroll;
    }).toPromise().then(x=>{
      debugger;
      console.log(x);
      this.selectedEmpPayroll = x;
    })
  }
  PostEmpPayroll(emppayroll : Payroll)
  {
    var body = JSON.stringify(emppayroll);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Post, headers : headerOptions});
    return this.http.post('http://localhost:51504/api/EmpPayrolls',body,requestOptions).map(x=>x.json());
  }
  PutEmpPayroll(id, emppayroll)
  {    
    var body = JSON.stringify(emppayroll);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Put, headers : headerOptions});
    return this.http.put('http://localhost:51504/api/EmpPayrolls/' + id,
    body,
    requestOptions).map(res=>res.json());
  }

}
