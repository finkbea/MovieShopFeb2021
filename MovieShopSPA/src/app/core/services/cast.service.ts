import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cast } from 'src/app/shared/models/cast';
import { MovieCard } from 'src/app/shared/models/moviecard';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CastService {

  constructor(private apiService: ApiService) { }

  getCastDetails(id:number | undefined) : Observable<Cast>{
    return this.apiService.getDetails('cast',id);
  }

}
