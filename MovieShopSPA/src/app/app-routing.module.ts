import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { CastComponent } from './cast/cast.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { HomeComponent } from './home/home/home.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MoviedetailsComponent } from './movies/movie-details/movie-details.component';

const routes: Routes = [
    {path: "", component: HomeComponent},
    {path: ":sstring", component:HomeComponent},
    {path: "movies/genre/:id", component: MovieCardListComponent},
    {path: "movies/:id", component:MoviedetailsComponent},
    {path: "cast/:id", component:CastComponent},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
