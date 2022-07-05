import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Role } from '@models/role';
import { OperationResult } from '@utilities/operation-result';

@Injectable({
  providedIn: 'root'
})
export class SettingService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(roleName: string) {
    return this.http.post<OperationResult>(`${this.baseUrl}PermissionSetting/CreateNewRoles`, roleName);
  }

  delete(roleName: string) {
    return this.http.put<OperationResult>(`${this.baseUrl}PermissionSetting/DeleteRole`, roleName);
  }

  getRoles() {
    return this.http.get<Role[]>(`${this.baseUrl}PermissionSetting/GetRoles`);
  }
}
