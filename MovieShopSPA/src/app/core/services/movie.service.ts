import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { MovieDetails } from 'src/app/shared/models/moviedetails';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService: ApiService) { }

  getTop30GrossingMovies() :Observable<MovieCard[]> {
    return this.apiService.getAll('movies/toprevenue');
  }
  getMoviesInGenre(id: number | undefined) :Observable<MovieCard[]> {
    return this.apiService.getAll('movies/genre/'+id);
  }

  /*getMovie(id: number) :Observable<MovieDetails> {
    //return this.apiService.getById({'movies'}, id);
  }*/
  getDetails(id: number | undefined): Observable<MovieDetails> {
    return this.apiService.getDetails(`${'movies'}`,id);
  }

  getStringDetails(sstring: string | undefined): Observable<MovieCard[]> {
    return this.apiService.getStringDetails(`${'movies/search/'}`,sstring);
  }

  getAllMovies() : Observable<MovieCard[]>{
    return this.apiService.getAll('movies');
  }


}
