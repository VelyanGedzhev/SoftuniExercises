import { AbstractControl, ValidationErrors } from "@angular/forms";

export function customEmailValidator(control: AbstractControl): ValidationErrors | null {
    const value = control.value;

    if (!value) {
        return null;
    }

    if (!/.{6,}@gmail\.(bg|com)/.test(value)) {
        return {
            email: true
        }
    }

    return null;
}

export function passwordMatch(passwordFormControl: AbstractControl) {
    return (repeatPasswordFormControl: AbstractControl) => {
        if (passwordFormControl.value !== repeatPasswordFormControl.value) {
            return {
                passwordMatch: true
            }
        }

        return null;
    }
}