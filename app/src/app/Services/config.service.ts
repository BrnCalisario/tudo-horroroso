import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() 
  {
    var token = sessionStorage.getItem("id_token") && ''
    this.defaultHeader.append('Authorization', 'Bearer ' + token)
  }

  public defaultHeader : HttpHeaders = new HttpHeaders()

  backendURL = "http://localhost:5122"
}