import { Component, OnInit } from '@angular/core';
import { Pagination } from '@utilities/pagination-utility';
import { UserService } from '@services/user.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgSnotifyService } from '@services/ng-snotify.service';
import { User } from '@models/user';
import { CaptionConstants, MessageConstants } from '@constants/message.enum';
import { KeyValuePair } from '@utilities/key-value-pair';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-main',
  templateUrl: './user-main.component.html',
  styleUrls: ['./user-main.component.scss']
})
export class UserMainComponent implements OnInit {
  pagination: Pagination = <Pagination>{
    pageNumber: 1,
    pageSize: 12,
  }
  userName: string = '';
  dataUser: User[] = [];
  listUser: KeyValuePair[] = [];

  constructor(
    private userService: UserService,
    private spinner: NgxSpinnerService,
    private snotify: NgSnotifyService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getListUser();
    this.getData();
  }

  search() {
    this.pagination.pageNumber === 1 ? this.getData() : this.pagination.pageNumber = 1;
  }

  getData() {
    this.spinner.show();
    this.userService.getUserPagination(this.pagination, this.userName)
      .subscribe({
        next: (res) => {
          this.dataUser = res.result;
          this.pagination = res.pagination;
          this.spinner.hide();
        }, error: () => {
          this.spinner.hide();
          this.snotify.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
        }
      });
  }

  getListUser() {
    this.spinner.show();
    this.userService.getListUser().subscribe({
      next: (res) => {
        this.listUser = res;
        this.spinner.hide();
      }, error: () => {
        this.spinner.hide();
        this.snotify.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
      }
    });
  }

  addNew() {
    this.router.navigate(['setting/user/add']);
  }

  edit(user: User) {
    this.router.navigate(['setting/user/edit', user.userName]);
  }

  delete(user: User) {
    this.snotify.confirm(MessageConstants.CONFIRM_DELETE_MSG, MessageConstants.CONFIRM_DELETE, () => {
      this.spinner.show();
      this.userService.delete(user).subscribe({
        next: (res) => {
          if (res) {
            this.snotify.success(MessageConstants.DELETED_OK_MSG, CaptionConstants.SUCCESS);
            this.getData();
          }
          else
            this.snotify.error(MessageConstants.DELETED_ERROR_MSG, CaptionConstants.ERROR);
          this.spinner.hide();
        }, error: () => {
          this.spinner.hide();
          this.snotify.error(MessageConstants.UN_KNOWN_ERROR, CaptionConstants.ERROR);
        }
      });
    });
  }

  changePage(event: any) {
    this.pagination.pageNumber = event.page;
    this.getData();
  }
}
