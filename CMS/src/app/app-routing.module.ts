import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContentComponent } from "./shared/components/layout/content/content.component";
import { LoginComponent } from '../app/components/login/login.component';
import { AuthGuard } from '@guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: ContentComponent,
    children: [
      {
        path: 'setting',
        loadChildren: () => import('./components/setting/setting.module').then(m => m.SettingModule)
      },
      {
        path: 'position',
        loadChildren: () => import('./components/position/position.module').then(m => m.PositionModule)
      }
    ]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: '**',
    redirectTo: '',
    component: ContentComponent
  }
];

@NgModule({
  imports: [[RouterModule.forRoot(routes, {
    anchorScrolling: 'enabled',
    scrollPositionRestoration: 'enabled',
    relativeLinkResolution: 'legacy'
})],
],
  exports: [RouterModule]
})
export class AppRoutingModule { }
