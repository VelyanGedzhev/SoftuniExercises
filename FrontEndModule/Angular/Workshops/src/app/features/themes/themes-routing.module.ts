import { RouterModule, Routes } from "@angular/router";
import { NewThemePageComponent } from "./new-theme-page/new-theme-page.component";
import { ThemeDetailsPageComponent } from "./theme-details-page/theme-details-page.component";
import { ThemesPageComponent } from "./themes-page/themes-page.component";

const routes: Routes = [
    {
        path: 'themes', 
        component: ThemesPageComponent
    },
    {
        path: 'themes/new',
        component: NewThemePageComponent
    },
    {
        path: 'themes/:id',
        component: ThemeDetailsPageComponent
    }
];

export const ThemesRoutingModule = RouterModule.forChild(routes);