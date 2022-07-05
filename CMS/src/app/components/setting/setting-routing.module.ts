import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'permission',
    loadChildren: () => import('./permission/permission.module').then(m => m.PermissionModule)
  },
  {
    path: 'user',
    loadChildren: () => import('./user-management/user-management.module').then(m => m.UserManagementModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
