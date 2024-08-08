import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from 'src/app/_models/role';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  showSignIn: boolean = false;
  showSignUp: boolean = false;
  modelLogin: any = {};
  modelRegister: any = {};
  registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        userName: ['', Validators.required],
        email: ['', Validators.required],
        phone: [null, Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(8),
          ],
        ],
        confirmPassword: ['', Validators.required],
      },
      { validator: this.passwordMatchValidator }
    );
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password')?.value === g.get('confirmPassword')?.value
      ? null
      : { mismatch: true };
  }

  login() {
    this.authService.login(this.modelLogin).subscribe(
      (next) => {
        this.showSignIn = false;
        this.alertify.success('Đăng nhập thành công');
      },
      (error) => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['home']);
      }
    );
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    this.authService.decodedToken = null;
    this.router.navigate(['home']);
  }

  register() {
    if (this.registerForm.valid) {
      this.modelRegister = Object.assign({}, this.registerForm.value);
      this.authService.register(this.modelRegister).subscribe(
        () => {
          this.showSignUp = false;
          this.alertify.success('Đăng ký tài khoản thành công');
        },
        (error) => {
          this.alertify.error(error);
        },
        () => {
          // this.authService.login(this.user).subscribe(() => {
          //   this.router.navigate(['home']);
          // });
        }
      );
    }
  }

  isCandidate() {
    return this.authService.isInRole(Role.Candidate);
  }

  isRecruiter() {
    return this.authService.isInRole(Role.Recruiter);
  }

  show(isLogin: boolean = true) {
    if (isLogin) {
      this.showSignIn = true;
    } else {
      this.showSignUp = true;
    }
  }

  hide(isLogin: boolean = true) {
    if (isLogin) {
      this.showSignIn = false;
    } else {
      this.showSignUp = false;
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
