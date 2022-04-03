import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginFormGroup: FormGroup = this.formBuilder.group({
    'email': new FormControl(null, [
        Validators.required,
        Validators.email
      ]),
    "password": new FormControl(null, [
        Validators.required,
        Validators.minLength(5)
    ])
  });

  constructor(
    private userService: UserService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  loginHandler(): void {
    //TODO validate user's data
    this.userService.login();
    this.router.navigate(['/home']);
  }

  handleLogin(): void {
     
  }
}
