import { Component, OnInit } from '@angular/core';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { User } from 'src/app/shared/models/user';
import { AuthenticationService } from '../../services/authentication.service';
import { MovieService } from '../../services/movie.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isAuthenticated: boolean | undefined;
  currentUser: User | undefined;
  searchString='';

  //search bar stuff
  movies: MovieCard[] | undefined;

  constructor(private authService: AuthenticationService, private movieService: MovieService) { }

  ngOnInit(): void {
    this.authService.IsAuthenticated.subscribe(
      auth => {
        this.isAuthenticated = auth;
        console.log('Auth Status'+this.isAuthenticated);
      }
    );
  }
  //TODO
  search(): void {
    this.movieService.getAllMovies().subscribe(
      m => {
        this.movies= m;
      }
    );
    var temp: MovieCard[] =[];
    if (this.movies!=null){
      for (let m of this.movies){
        //console.log(m.title);
        if (m.title.includes(this.searchString)){
          console.log(m.title);
          if (temp != undefined){
            temp[temp.length-1]=m;
            console.log(temp);
          }
        }
      }
    }
    this.movies=temp;
  }

  logout() : void {
    this.authService.logout;
  }

}
