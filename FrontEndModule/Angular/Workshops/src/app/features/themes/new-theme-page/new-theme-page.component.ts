import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ThemeService } from 'src/app/core/theme.service';

@Component({
  selector: 'app-new-theme-page',
  templateUrl: './new-theme-page.component.html',
  styleUrls: ['./new-theme-page.component.css']
})
export class NewThemePageComponent implements OnInit {

  constructor(
    private router: Router,
    private themeService: ThemeService) { }

  ngOnInit(): void {
  }

  submitNewTheme(newThemeForm: NgForm) {
    const themeToAdd = newThemeForm.form.value;
    
    this.themeService.addTheme$(themeToAdd).subscribe({
      next: (theme) => {
        console.log(theme);
        this.router.navigate(['/themes']);
      },
      error: (err) => {
        console.log(err.error.message);
      }
    });
  }

  navigateToHome() {
    return this.router.navigate(['/home']);
  }
}
