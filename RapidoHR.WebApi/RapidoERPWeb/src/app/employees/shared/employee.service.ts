import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { Http, Response, Headers, RequestOptions, RequestMethod, Jsonp } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Guid } from "guid-typescript";

@Injectable()
export class EmployeeService {

  selectedEmployee : Employee;
  employeeList : Employee[];
  constructor(private http : Http) { }

  PostEmployee(emp : Employee)
  {
    var body = JSON.stringify(emp);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Post, headers : headerOptions});
    return this.http.post('http://localhost:80/api/EmployeeDetails',body,requestOptions).map(x=>x.json())
    .catch(this.handleError);
  }
  getEmployeeList()
  {    
    this.http.get('http://localhost:80/api/EmployeeDetails')
    .map((data : Response)=>{
      return data.json() as Employee[];
    }).toPromise().then(x=>{           
      this.employeeList = x;
    })
    .catch(this.handleError)
  }
  PutEmployee(id, emp)
  {    
    var body = JSON.stringify(emp);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method:RequestMethod.Put, headers : headerOptions});
    return this.http.put('http://localhost:80/api/EmployeeDetails/' + id,
    body,
    requestOptions).map(res=>res.json())
    .catch(this.handleError);
  }
  deleteEmployee(id : Guid)
  {
    return this.http.delete('http://localhost:80/api/EmployeeDetails/' + id).map(res=>res.json())
    .catch(this.handleError);
  }
  handleError(error: Response)
  {
    debugger;
    console.log(error.text());
    return Observable.throw(error);
  }

}
