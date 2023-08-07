import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from '../interfaces/Login';
import { UserService } from '../Services/UserService.service'

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  nome = ""
  senha = ""

  user: Login = {
    nome: '',
    senha: ''
  }

  constructor(private router: Router) { }

  passwordChanged(event: any) {
    this.senha = event
  }

  login() {
  }
}
