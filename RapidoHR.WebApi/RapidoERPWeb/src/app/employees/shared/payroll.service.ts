import { Injectable } from '@angular/core';
import { Payroll } from './payroll.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Guid } from "guid-typescript";

@Injectable()
export class PayrollService {

  selectedEmpPayroll : Payroll;
  constructor(private http : Http) { }
  
  getEmployeePayroll(empcode : string)
  {
    return this.http.get('http://localhost:80/api/EmpCodePayroll/' + empcode)
    .map(res=>res.json())
    .catch(this.handleError);   
  }
  PostEmpPayroll(emppayroll : Payroll)
  {
    var body = JSON.stringify(emppayroll);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Post, headers : headerOptions});
    return this.http.post('http://localhost:80/api/EmpPayrolls',body,requestOptions).map(x=>x.json())
    .catch(this.handleError);
  }
  PutEmpPayroll(id, emppayroll)
  {    
    var body = JSON.stringify(emppayroll);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Put, headers : headerOptions});
    return this.http.put('http://localhost:80/api/EmpPayrolls/' + id,
    body,
    requestOptions).map(res => res.json())
    .catch(this.handleError);
  }
  handleError(error: Response)
  {
    debugger;
    console.log(error.text());
    return Observable.throw(error);
  }

}
