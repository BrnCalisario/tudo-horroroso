import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../interfaces/Usuario';
import { ConfigService } from './config.service';
import { Login } from '../interfaces/Login';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient, private config: ConfigService) { }

  add(user: User) {
    return this.http.post(this.config.backendURL + "/user/register", user)
  }

  Login(user : Login){
    return this.http.post(this.config.backendURL + '/user/LoginUser', user)
  }
}
