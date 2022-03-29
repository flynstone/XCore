import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PasswordConfirmationValidatorService } from 'src/app/shared/custom-validators/password-confirmation-validator.service';
import { AuthenticationService } from 'src/app/shared/_services/authentication.service';
import { UserForRegistrationDto } from '../_interfaces/user/userForRegistrationDto';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {

  public registerForm: FormGroup;

  constructor(private authService: AuthenticationService, private passValidator: PasswordConfirmationValidatorService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(""),
      lastName: new FormControl(""),
      email: new FormControl("", [Validators.required, Validators.email]),
      password: new FormControl("", [Validators.required]),
      confirm: new FormControl("")
    });
  }

  validateControl = (item: string) => {
    return this.registerForm.controls[item].invalid && this.registerForm.controls[item].touched;
  }

  public hasError = (msg: string, error: string) => {
    return this.registerForm.controls[msg].hasError(error);
  }

  public registerUser = (registerFormValue) => {
    const formValues = { ...registerFormValue };

    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };

    this.authService.registerUser("api/accounts/registration", user)
    .subscribe(_ => {
      console.log("Successful registration");
    },
    error => {
      console.log(error.error.errors);
    })
  }
}
