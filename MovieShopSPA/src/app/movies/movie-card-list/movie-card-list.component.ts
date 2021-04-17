import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/moviecard';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {
  
  name?: string;
  id?: number;
  movies: MovieCard[] | undefined;

  constructor(private movieService: MovieService, private route: ActivatedRoute, private router: Router) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.getAll('id');
      this.getMovies();
    });
  }
  private getMovies(){
    this.movieService.getMoviesInGenre(this.id).subscribe (m => this.movies=m);
  }

}
