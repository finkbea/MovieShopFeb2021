import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { HomeComponent } from './home/home/home.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MoviedetailsComponent } from './movies/movie-details/movie-details.component';

const routes: Routes = [
    {path: "", component: HomeComponent},
    {path: "genre/movies/:id", component: MovieCardListComponent},
    {path: "movies/:id", component:MoviedetailsComponent},
    {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
