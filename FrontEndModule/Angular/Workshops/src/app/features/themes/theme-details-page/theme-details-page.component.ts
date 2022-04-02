import { Component, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IPost, ITheme } from 'src/app/core/interfaces';
import { ThemeService } from 'src/app/core/theme.service';
import { UserService } from 'src/app/core/user.service';

@Component({
  selector: 'app-theme-details-page',
  templateUrl: './theme-details-page.component.html',
  styleUrls: ['./theme-details-page.component.css']
})
export class ThemeDetailsPageComponent implements OnInit {

  theme: ITheme;
  isLogged: boolean = false;
  isSubscribed: boolean = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    private themeService: ThemeService,
    private userService: UserService) { }

  ngOnInit(): void {
    const themeId = this.activatedRoute.snapshot.params['id'];
    console.log(themeId);
    this.themeService.loadThemeById(themeId).subscribe(
      theme => {
        this.theme = theme;
        this.isLogged = this.userService.isLogged;
        console.log(theme.posts)
        if (this.isLogged) {
          this.isSubscribed = this.theme.subscribers.includes('5fa64b162183ce1728ff371d');
        }
      }
    );
  }

  isCommentLiked(comment: IPost) {
    return comment.likes.includes('5fa64b162183ce1728ff371d');
  }
}
