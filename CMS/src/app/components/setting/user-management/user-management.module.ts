import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserManagementRoutingModule } from './user-management-routing.module';
import { UserMainComponent } from './user-main/user-main.component';
import { UserAddComponent } from './user-add/user-add.component';
import { UserUpdateComponent } from './user-update/user-update.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UserMainComponent,
    UserAddComponent,
    UserUpdateComponent,
  ],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class UserManagementModule { }
