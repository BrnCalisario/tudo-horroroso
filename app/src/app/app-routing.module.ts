import { NgModule } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RegisterComponent } from './register/register.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { ViewRecipePageComponent } from './view-recipe-page/view-recipe-page.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { PerfilPageComponent } from './perfil-page/perfil-page.component';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';

const routes: Routes = [
  {
    path: '',
    title: 'homePage',
    component: HomePageComponent
  },
  {
    path: 'login',
    title: "Login",
    component: LoginPageComponent
  },
  {
    path: 'register',
    title: "Cadastro",
    component: RegisterComponent
  },
  {
    path: 'recipe',
    title: "Recipe",
    component: RecipeListComponent
  },
  {
    path: 'create',
    title: "Criar",
    component: CreateRecipeComponent
  },
  {
    path: 'viewRecipe',
    title: "Page recipe",
    component: ViewRecipePageComponent
  },
  {
    path: 'profile',
    title: "Seu Perfil",
    component: PerfilPageComponent
  },
  {
    path: '**',
    title: "Error",
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
