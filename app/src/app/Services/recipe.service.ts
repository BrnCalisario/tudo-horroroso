import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recipe } from '../DTO/recipe';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(private http: HttpClient, private config: ConfigService) { }

  add(recipe : Recipe)
  {
    return this.http.post(this.config.backendURL + "/recipe/create", recipe)
  }
}
