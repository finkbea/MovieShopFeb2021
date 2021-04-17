import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CastService } from '../core/services/cast.service';
import { MovieService } from '../core/services/movie.service';
import { Cast } from '../shared/models/cast';
import { MovieCard } from '../shared/models/moviecard';

@Component({
  selector: 'app-cast',
  templateUrl: './cast.component.html',
  styleUrls: ['./cast.component.css']
})
export class CastComponent implements OnInit {

  id?: number;
  movies: MovieCard[] | undefined;
  cast: Cast | undefined;

  constructor(private movieService: MovieService, private castService: CastService, private route: ActivatedRoute, private router: Router) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = +params.getAll('id');
      this.getMe();
    });
  }

  private getMe(){
    this.castService.getCastDetails(this.id).subscribe(c => this.cast=c);
  }


}
