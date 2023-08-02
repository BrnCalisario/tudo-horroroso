import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { RegisterComponent } from './register/register.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { ViewRecipePageComponent } from './view-recipe-page/view-recipe-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RecipeItemComponent,
    RegisterComponent,
    LoginPageComponent,
    ViewRecipePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
