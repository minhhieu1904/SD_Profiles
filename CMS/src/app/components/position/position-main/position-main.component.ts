import { Component, OnInit } from '@angular/core';
import { NgSnotifyService } from '@services/ng-snotify.service';
import { PositionService } from '@services/position.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-position-main',
  templateUrl: './position-main.component.html',
  styleUrls: ['./position-main.component.scss']
})
export class PositionMainComponent implements OnInit {

  constructor(
    private positionService: PositionService,
    private spinner: NgxSpinnerService,
    private snotify: NgSnotifyService
  ) { }

  ngOnInit(): void {
  }

}
