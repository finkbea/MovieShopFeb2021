import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  //private readonly HttpClient _httpClient; 
  constructor(protected http: HttpClient) {

   }

  getAll(path: string): Observable<any[]> {
    return this.http.get(`${environment.apiUrl}${path}`)
    .pipe(
      map( resp => resp as any[])
    ) ;
  }

  getDetails(path: string, id?:number) : Observable<any> {
    return this.http.get(`${environment.apiUrl}${path}`+'/'+id).pipe(
      map( resp => resp as any)
    );
  }
  
  /*getNodeMajorVersion(path: string, id?: number): Observable<any> {
    return 0;
  }*/
  
}

