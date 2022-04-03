import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  handleRegister(){
    console.log('successfull registration')
  }
}
