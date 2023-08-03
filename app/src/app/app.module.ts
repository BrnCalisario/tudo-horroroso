import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { RegisterComponent } from './register/register.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import { ViewRecipePageComponent } from './view-recipe-page/view-recipe-page.component';
import { PerfilPageComponent } from './perfil-page/perfil-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    RecipeItemComponent,
    RegisterComponent,
    LoginPageComponent,
    ViewRecipePageComponent,
    RecipeListComponent,
    LoginPageComponent,
    CreateRecipeComponent,
    IngredientListComponent,
    PerfilPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
