import { Component, OnInit } from '@angular/core';
import { AuthenticationService, User } from '../shared/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],  
  providers : [AuthenticationService]
})
export class LoginComponent implements OnInit {

  public user = new User('','');
  public errorMsg = '';
  constructor(private _service:AuthenticationService) { }

  ngOnInit() {
  }

  login() {
    debugger;
    if(!this._service.login(this.user)){
        this.errorMsg = 'Failed to login';
    }
}
}
