import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(private authService: AuthenticationService, private movieService: MovieService, private router: Router) { }

  ngOnInit(): void {
    this.authService.IsAuthenticated.subscribe(
      auth => {
        this.isAuthenticated = auth;
        console.log('Auth Status'+this.isAuthenticated);
      }
    );
  }

  search(): void {
    console.log("the fuck");
    this.router.navigate(['movies/search/', this.searchString]);
    console.log("the fuck");
  }

  logout() : void {
    this.authService.logout;
  }

}
