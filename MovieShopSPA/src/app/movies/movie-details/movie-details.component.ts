import { Component, Input, OnInit } from '@angular/core';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieDetails } from 'src/app/shared/models/moviedetails';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-moviedetails',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MoviedetailsComponent implements OnInit {

  movie: MovieDetails | undefined;
  id?: number;

  constructor(private movieService: MovieService, private route: ActivatedRoute, private router: Router) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.getAll('id');
      this.getMovieDetails();
    });
  }
  private getMovieDetails(){
    this.movieService.getMovieDetails(this.id).subscribe (m => this.movie=m);
  }


}
