import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/moviecard';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @Input() sstring: string | undefined;

  movies: MovieCard[] | undefined;
  constructor(private movieService: MovieService, private router: Router, private route: ActivatedRoute) {
    route.params.subscribe(val =>{
      this.populate();
    });
   }

  ngOnInit() {
    this.populate();
  }

  ngOnChanges(){
    this.populate();
  }
  
  populate(){
    this.sstring=this.router.url.substring(1);
    //normal home page
    console.log("sstring: "+this.sstring);
    if (this.sstring == undefined || this.sstring==""){
      this.movieService.getTop30GrossingMovies().subscribe(
        m => {
          this.movies = m;
          console.table(this.movies);
        }
      )
    }
    //search bar active
    else {
      this.movieService.getStringDetails(this.sstring).subscribe(
        m => {
          this.movies= m;
          console.table(this.movies);
        }
      );
    }
  }
}