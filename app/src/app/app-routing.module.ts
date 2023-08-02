import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RegisterComponent } from './register/register.component';

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
