import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from 'src/app/aside/aside.component';
import { PostListComponent } from './post-list/post-list.component';
import { ThemeListItemComponent } from './theme-list-item/theme-list-item.component';
import { ThemeListComponent } from './theme-list/theme-list.component';
import { ThemesPageComponent } from './themes-page/themes-page.component';
import { ThemesRoutingModule } from './themes-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ThemeDetailsPageComponent } from './theme-details-page/theme-details-page.component';
import { NewThemePageComponent } from './new-theme-page/new-theme-page.component';



@NgModule({
  declarations: [
    ThemeListComponent,
    AsideComponent,
    ThemeListItemComponent,
    PostListComponent,
    ThemesPageComponent,
    ThemeDetailsPageComponent,
    NewThemePageComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ThemesRoutingModule
  ],
  exports: [
  ]
})
export class ThemesModule { }
