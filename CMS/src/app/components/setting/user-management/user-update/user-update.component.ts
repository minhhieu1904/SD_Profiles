import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CaptionConstants, MessageConstants } from '@constants/message.enum';
import { Role } from '@models/role';
import { User } from '@models/user';
import { NgSnotifyService } from '@services/ng-snotify.service';
import { SettingService } from '@services/setting.service';
import { UserService } from '@services/user.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.scss']
})
export class UserUpdateComponent implements OnInit {
  user: User = <User>{};
  userName: string = '';
  checkedAll: boolean = false;
  constructor(
    private router: Router,
    private userService: UserService,
    private settingService: SettingService,
    private spinner: NgxSpinnerService,
    private snotify: NgSnotifyService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.userName = this.route.snapshot.paramMap.get("userName");
    this.getData();
  }

  back() {
    this.router.navigate(['setting/user']);
  }

  getData() {
    this.spinner.show();
    this.userService.getUserDetail(this.userName)
      .subscribe({
        next: (res) => {
          this.user = res;
          this.checkedAll = this.user.roles?.filter(x => x.isActive)?.length == this.user.roles?.length ? true : false;
          this.spinner.hide();
        }, error: () => {
          this.spinner.hide();
          this.snotify.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
        }
      })
  }

  save() {
    this.spinner.show();
    this.user.avatar = !this.user.avatar.includes("base64") ? '' : this.user.avatar;
    this.userService.update(this.user).subscribe({
      next: (res) => {
        if (res) {
          this.snotify.success(MessageConstants.CREATED_OK_MSG, CaptionConstants.SUCCESS);
          this.back();
        }
        else
          this.snotify.error(MessageConstants.CREATED_ERROR_MSG, CaptionConstants.ERROR);
        this.spinner.hide();
      }, error: () => {
        this.spinner.hide();
        this.snotify.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
      }
    })
  }

  uploadAvatar(event) {
    let reader = new FileReader(); // HTML5 FileReader API
    if (event.target.files && event.target.files[0]) {
      reader.readAsDataURL(event.target.files[0]);

      //When file uploads set it to file formcontrol
      reader.onload = (e) => {
        // called once readAsDataURL is completed
        this.user.avatar = e.target.result.toString();
      };
    }
  }

  checkedRole(item: Role) {
    item.isActive = !item.isActive;
    this.checkedAll = this.user.roles?.length === this.user.roles?.filter(x => x.isActive)?.length ? true : false;
  }

  checkedAllRole() {
    if (!this.checkedAll) {
      this.user.roles?.forEach(item => item.isActive = true);
    }
    else {
      this.user.roles?.forEach(item => item.isActive = false);
    }
  }
}
