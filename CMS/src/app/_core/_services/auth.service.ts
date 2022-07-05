import { Injectable } from '@angular/core';
import { LocalStorageConstants } from '@constants/local-storage.constants';
import { JwtHelperService } from "@auth0/angular-jwt";
import { HttpClient } from '@angular/common/http';
import { environment } from '@env/environment';
import { UserForLoginParam } from '@params/user-for-login.param';
import { UserForLogged } from '@models/user-for-logged';
import { ApplicationUser } from '@models/application-user';
import { MenuWithRole } from '@models/menu';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'Auth/';
  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient, private router: Router) { }

  login(model: UserForLoginParam) {
    return this.http.post<UserForLogged>(this.baseUrl + 'login', model).pipe(
      tap(res => {
        if (res) {
          localStorage.setItem(LocalStorageConstants.TOKEN, res.token);
          localStorage.setItem(LocalStorageConstants.USER, JSON.stringify(res.user));
          localStorage.setItem(LocalStorageConstants.MENUS, JSON.stringify(res.menus));
        }
      })
    );
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  loggedIn() {
    const token: string = localStorage.getItem(LocalStorageConstants.TOKEN);
    const user: ApplicationUser = JSON.parse(localStorage.getItem(LocalStorageConstants.USER));
    const menus: MenuWithRole[] = JSON.parse(localStorage.getItem(LocalStorageConstants.MENUS));
    return !(!user || !menus) || !this.jwtHelper.isTokenExpired(token);
  }
}
