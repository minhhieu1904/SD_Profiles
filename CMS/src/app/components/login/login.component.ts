import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLoginParam } from '@params/user-for-login.param';
import { AuthService } from '@services/auth.service';
import { NgSnotifyService } from '@services/ng-snotify.service';
import { CaptionConstants, MessageConstants } from '@constants/message.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public show: boolean = false;
  public loginForm: FormGroup;
  public errorMessage: any;
  public showLoader: boolean = false;

  constructor(
    public authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private snotifyService: NgSnotifyService
    ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      remember: [false]
    });
  }

  ngOnInit() {
  }

  showPassword() {
    this.show = !this.show;
  }

  login() {
    let userParam: UserForLoginParam = {
      userName: this.loginForm.value['username'],
      passWord: this.loginForm.value['password'],
      rememberMe: this.loginForm.value['remember']
    };
    this.authService.login(userParam).subscribe({
      next: (res) => {
        if (res) {
          this.snotifyService.success(MessageConstants.LOGGED_IN, CaptionConstants.SUCCESS);
          this.router.navigate(['/setting']);
        } else {
          this.snotifyService.error(MessageConstants.LOGIN_FAILED, CaptionConstants.ERROR);
        }
      },
      error: () => {
        this.snotifyService.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
      },
      complete: () => {
        this.router.navigate(['/setting']);
      }
    });
  }
}
