import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  constructor() { }

  backendURL = "http://localhost:5122"
}