import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from 'src/app/shared/models/login';
import { ApiService } from './api.service';
import { JwtStorageService } from './jwt-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private apiService: ApiService, private jwtStorageService: JwtStorageService) { }

  login(userLogin: Login) :Observable<boolean>{
    return this.apiService.create('account/login', userLogin)
    .pipe( map (response => {
      if (response) {
        //save the response token to localstorage
        this.jwtStorageService.saveToken(response.token);
        return true;
      }
      return false;
    }));

    //take un/pw from login component and post it to API
    //once API returns token. we need to store the token in localstorage of the browser
    //othwerwise return false to component to that component and show the message in the UI
  }

  logout() {
    this.jwtStorageService.destroyToken();
    //we remove the token from local storage
  }

  decodeToken() {
    //it will read the token from local storage and decode it and put in User object
  }
}
