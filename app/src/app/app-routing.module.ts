import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RegisterComponent } from './register/register.component';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';

const routes: Routes = [
  {
    path: '',
    title: 'homePage',
    component: HomePageComponent
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
