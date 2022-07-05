import { Component, OnInit } from '@angular/core';
import { UserService } from '@services/user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgSnotifyService } from '@services/ng-snotify.service';
import { User } from '@models/user';
import { CaptionConstants, MessageConstants } from '@constants/message.enum';
import { Role } from '@models/role';
import { SettingService } from '@services/setting.service';
import { environment } from '@env/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.scss']
})
export class UserAddComponent implements OnInit {
  user: User = <User>{};
  checkedAll: boolean = false;
  imageUser: any = environment.imageUserDefault;
  constructor(
    private userService: UserService,
    private spinner: NgxSpinnerService,
    private snotify: NgSnotifyService,
    private settingService: SettingService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getRoles();
  }

  back() {
    this.router.navigate(['setting/user']);
  }

  getRoles() {
    this.spinner.show();
    this.settingService.getRoles().subscribe({
      next: (res) => {
        this.user.roles = res;
        this.user.roles?.forEach(item => item.isActive = false);
        this.spinner.hide();
      }, error: () => {
        this.spinner.hide();
        this.snotify.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
      }
    })
  }

  save(type: string) {
    this.spinner.show();
    this.user.avatar = !this.user.avatar ? null : this.user.avatar;
    this.userService.create(this.user).subscribe({
      next: (res) => {
        if (res.data === 'Exists')
          this.snotify.error(res.error, CaptionConstants.ERROR);
        else if (res.isSuccess) {
          this.snotify.success(MessageConstants.CREATED_OK_MSG, CaptionConstants.SUCCESS);
          type === 'SAVE' ? this.back() : this.reset();
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

  reset() {
    this.user.roles?.forEach(item => item.isActive = false);
    this.user = <User>{
      avatar: null,
      email: null,
      name: null,
      userName: null,
      phoneNumber: null,
      roles: this.user.roles
    };
    this.checkedAll = false;
    this.imageUser = environment.imageUserDefault;
  }

  uploadAvatar(event) {
    let reader = new FileReader(); // HTML5 FileReader API
    if (event.target.files && event.target.files[0]) {
      reader.readAsDataURL(event.target.files[0]);

      //When file uploads set it to file formcontrol
      reader.onload = (e) => {
        // called once readAsDataURL is completed
        this.imageUser = e.target.result.toString();
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
