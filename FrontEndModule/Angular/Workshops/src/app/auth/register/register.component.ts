import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ICreateUserDto, UserService } from 'src/app/core/user.service';
import { customEmailValidator, passwordMatch } from '../login/util';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  passwordControl = new FormControl(null, [Validators.required, Validators.minLength(4)]);

  get passwordsGroup(): FormGroup {
    return this.registerFormGroup.controls['passwords'] as FormGroup;
  }

  registerFormGroup: FormGroup = this.formBuilder.group({
    'username': new FormControl(null, [Validators.required, Validators.minLength(5)]),
    'passwords': new FormGroup({
      'password': this.passwordControl,
      'repeatPassword': new FormControl(null, [passwordMatch(this.passwordControl)]),
    }),
    'email': new FormControl(null, [Validators.required, customEmailValidator]),
    'telephone': new FormControl(),
    'telephoneRegion': new FormControl()
  });

  constructor(
    private formBuilder: FormBuilder, 
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
  }

  handleRegister(){
    const {username, email, passwords, telephone, telephoneRegion} = this.registerFormGroup.value;

    const body: ICreateUserDto = {
      username: username,
      email: email,
      password: passwords.password,
      ...(!!telephone && { telephone: telephoneRegion + telephone })
    }

    this.userService.register(body).subscribe(() => {
      this.router.navigate(['/home']);
    });
  }
}
