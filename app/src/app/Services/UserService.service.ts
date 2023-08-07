import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../interfaces/Usuario';
import { ConfigService } from './config.service';
import { Login } from '../interfaces/Login';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private config: ConfigService) { }

  Login(user : Login){
    return this.http.post<UserJWT>(this.config.Backend + '/user/LoginUser', user)
  }
}

export interface UserJWT {
  value : string
}