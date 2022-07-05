import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PositionRoutingModule } from './position-routing.module';
import { PositionMainComponent } from './position-main/position-main.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    PositionMainComponent
  ],
  imports: [
    CommonModule,
    PositionRoutingModule,
    SharedModule
  ]
})
export class PositionModule { }
