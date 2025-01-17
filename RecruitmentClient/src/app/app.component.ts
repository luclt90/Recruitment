import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserInfo } from './_models/user-info';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  constructor(private authService: AuthService) {}
  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
    const userLocal = localStorage.getItem('userInfo');
    if (userLocal) {
      const userInfo: UserInfo = JSON.parse(userLocal);
      if (userInfo) {
        this.authService.currentUser = userInfo;
      }
    }
  }
}
