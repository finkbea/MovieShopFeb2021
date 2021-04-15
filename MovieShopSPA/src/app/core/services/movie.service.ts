import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService: ApiService) { }

  getTop30GrossingMovies() :Observable<MovieCard[]> {
    return this.apiService.getAll('movies/toprevenue');
  }
}