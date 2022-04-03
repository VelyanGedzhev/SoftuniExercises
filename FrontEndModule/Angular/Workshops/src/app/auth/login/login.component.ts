import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/user.service';
import { customEmailValidator } from './util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  errorMessage: string;

  loginFormGroup: FormGroup = this.formBuilder.group({
    'email': new FormControl(null, [
        Validators.required,
        customEmailValidator
        // Validators.email
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
    this.router.navigate(['/home']);
  }

  handleLogin(): void {
    this.errorMessage = '';
    this.userService.login$(this.loginFormGroup.value ).subscribe({
     next: () => {
      this.router.navigate(['/home']);
     },
     error: (err) => {
       this.errorMessage = err.error.message;
     }
    });
  }
}
