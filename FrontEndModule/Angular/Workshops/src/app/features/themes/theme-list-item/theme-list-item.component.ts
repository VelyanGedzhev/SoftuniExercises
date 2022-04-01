import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ITheme } from 'src/app/core/interfaces';
import { UserService } from 'src/app/core/user.service';

@Component({
  selector: 'app-theme-list-item',
  templateUrl: './theme-list-item.component.html',
  styleUrls: ['./theme-list-item.component.css']
})
export class ThemeListItemComponent implements OnChanges {

  isLogged: boolean = this.userService.isLogged;
  isSubscribed: boolean = false;

  @Input() theme: ITheme;

  constructor(private userService: UserService) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.isSubscribed = this.theme.subscribers.includes('5fa64b162183ce1728ff371d');
  }
}
