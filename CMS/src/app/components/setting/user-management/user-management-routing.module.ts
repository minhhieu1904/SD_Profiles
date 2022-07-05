import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserMainComponent } from './user-main/user-main.component';
import { UserAddComponent } from './user-add/user-add.component';
import { UserUpdateComponent } from './user-update/user-update.component';

const routes: Routes = [
  {
    path: '',
    component: UserMainComponent
  },
  {
    path: 'add',
    component: UserAddComponent
  },
  {
    path: 'edit/:userName',
    component: UserUpdateComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserManagementRoutingModule { }
