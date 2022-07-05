import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PositionMainComponent } from './position-main/position-main.component';

const routes: Routes = [
  {
    path: '',
    component: PositionMainComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PositionRoutingModule { }
