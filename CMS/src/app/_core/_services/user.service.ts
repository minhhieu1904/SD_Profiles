import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';
import { KeyValuePair } from '@utilities/key-value-pair';
import { OperationResult } from '@utilities/operation-result';
import { User } from '@models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(user: User) {
    return this.http.post<OperationResult>(`${this.baseUrl}User/Create`, user);
  }

  update(user: User) {
    return this.http.put<boolean>(`${this.baseUrl}User/Update`, user);
  }

  delete(user: User) {
    return this.http.put<boolean>(`${this.baseUrl}User/Delete`, user);
  }

  changePassword(user: User) {
    return this.http.put<boolean>(`${this.baseUrl}User/ChangePassword`, user);
  }

  getListUser() {
    return this.http.get<KeyValuePair[]>(`${this.baseUrl}User/GetListUser`);
  }

  getUserPagination(pagination: PaginationParam, userName: string) {
    return this.http.get<PaginationResult<User>>(`${this.baseUrl}User/GetUserPagination`, { params: { ...pagination, userName } });
  }

  getUserDetail(userName: string) {
    return this.http.get<User>(`${this.baseUrl}User/GetUserDetail`, { params: { userName } });
  }
}
