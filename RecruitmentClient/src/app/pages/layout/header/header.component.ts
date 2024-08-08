import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SlideInOutAnimation } from 'src/app/animations';
import { LoginUser } from 'src/app/_models/login_user';
import { RegisterUser } from 'src/app/_models/register_user';
import { Role } from 'src/app/_models/role';
import { UserInfo } from 'src/app/_models/user-info';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

const enterTransition = transition(':enter', [
  style({
    opacity: 0,
  }),
  animate(
    '0.5s ease-in',
    style({
      opacity: 1,
    })
  ),
]);

const leaveTrans = transition(':leave', [
  style({
    opacity: 1,
  }),
  animate(
    '0.5s ease-out',
    style({
      opacity: 0,
    })
  ),
]);

const fadeIn = trigger('fadeIn', [enterTransition]);

const fadeOut = trigger('fadeOut', [leaveTrans]);

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  animations: [fadeIn, fadeOut, SlideInOutAnimation],
})
export class HeaderComponent implements OnInit {
  candidateActive: boolean = false;
  recruitActive: boolean = false;
  type: string;
  showSignIn: boolean = false;
  showSignUp: boolean = false;
  modelLogin: any = {};
  modelRegister: RegisterUser;
  registerForm: FormGroup;
  isShowProfile: boolean = false;
  animationState = 'out';

  constructor(
    public authService: AuthService,
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
    localStorage.removeItem('userInfo');
    this.authService.currentUser = null;
    this.authService.decodedToken = null;
    this.router.navigate(['home']);
  }

  register() {
    if (this.registerForm.valid && this.type) {
      this.modelRegister = this.getRegisterInfo();
      this.authService.register(this.modelRegister).subscribe(
        () => {
          this.showSignUp = false;
          this.alertify.success('Đăng ký tài khoản thành công');
        },
        (error) => {
          this.alertify.error(error.message);
        },
        () => {
          let loginUser: LoginUser = {
            email: this.modelRegister.email,
            password: this.modelRegister.password,
          };
          this.authService.login(loginUser).subscribe(() => {
            this.router.navigate(['home']);
          });
        }
      );
    }
  }

  getRegisterInfo(): RegisterUser {
    const registerUser: RegisterUser = {
      type: this.type,
      userName: this.registerForm.get('userName').value,
      password: this.registerForm.get('password').value,
      email: this.registerForm.get('email').value,
      phone: this.registerForm.get('phone').value,
    };

    return registerUser;
  }

  loggedIn() {
    return this.authService.loggedIn();
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

  showProfile() {
    this.isShowProfile = this.isShowProfile ? false : true;
  }

  toggleShowSubMenu() {
    this.animationState = this.animationState === 'out' ? 'in' : 'out';
  }

  activeCandidate() {
    this.candidateActive = true;
    this.recruitActive = false;

    this.type = Role.Candidate;
  }
  activeRecruit() {
    this.candidateActive = false;
    this.recruitActive = true;

    this.type = Role.Recruiter;
  }
}
