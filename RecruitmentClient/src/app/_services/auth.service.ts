import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { RegisterUser } from '../_models/register_user';
import { Role } from '../_models/role';
import { UserInfo } from '../_models/user-info';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';

  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: UserInfo;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          this.currentUser = user.userInfo;
          localStorage.setItem('token', user.token);
          localStorage.setItem('userInfo', JSON.stringify(user.userInfo));
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          localStorage.setItem('role', this.decodedToken.role);
        }
      })
    );
  }

  register(user: RegisterUser) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return token ? !this.jwtHelper.isTokenExpired(token) : false;
  }

  isInRole(userRole: Role) {
    const role = localStorage.getItem('role');
    return role == userRole;
  }
}
