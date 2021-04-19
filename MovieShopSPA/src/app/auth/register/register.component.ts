import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerFormGroup = new FormGroup({
    email: new FormControl('',[
      Validators.required,
      Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]),
    password: new FormControl('',[]),
    firstName: new FormControl('',[]),
    lastName: new FormControl('',[]),
    dateOfBirth: new FormControl('',[])
    });  

    invalidEmail: boolean = false;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  register() {
    console.log(this.registerFormGroup.value);
    /*if (this.registerFormGroup.invalid){
      this.invalidEmail=true;
      return;
    }*/
    this.authService.register(this.registerFormGroup.value).subscribe(
      (response)=>{
      this.router.navigate(['../login']);
    },
      (error) => {
        if (error){
          this.invalidEmail=true;
        }
      }
    )
  }
}
