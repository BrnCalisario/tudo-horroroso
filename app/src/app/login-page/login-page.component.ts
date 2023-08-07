import { Component } from '@angular/core';
import { Login } from '../interfaces/Login';
import { UserService } from '../Services/UserService.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  nome = ""
  senha = ""
  
  user: Login = {
    userName: '',
    password: ''
  }

  constructor(private userService : UserService, private router : Router) { }

  passwordChanged(event: any) {
    this.senha = event
  }

  login() {
    this.userService.Login(this.user).subscribe(x => {
      this.router.navigate(["/feed"])
    })
  }
}
