import { Component, OnInit } from '@angular/core';
import { CaptionConstants, MessageConstants } from '@constants/message.enum';
import { AuthService } from '@services/auth.service';
import { NgSnotifyService } from '@services/ng-snotify.service';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss']
})
export class MyAccountComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private snotify: NgSnotifyService
  ) { }

  ngOnInit() {
  }

  logout() {
    this.authService.logout();
    this.snotify.success(MessageConstants.LOGGED_OUT, CaptionConstants.SUCCESS);
  }
}
