import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './pages/layout/footer/footer.component';
import { HeaderComponent } from './pages/layout/header/header.component';
import { APP_BASE_HREF } from '@angular/common';
import { ResponsiveHeaderComponent } from './pages/layout/responsive-header/responsive-header.component';
import { AuthComponent } from './pages/layout/auth/auth.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ErrorInterceptorProvider } from './_services/error.intercepter.service';
import { JwtModule } from '@auth0/angular-jwt';
import { HomeComponent } from './pages/home/home.component';
import { NgSelectModule } from '@ng-select/ng-select';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    ResponsiveHeaderComponent,
    AuthComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    PaginationModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter,
        // allowedDomains: ['localhost:5000'],
        // disallowedRoutes: ['localhost:5000/auth'],
      },
    }),
  ],
  providers: [
    ErrorInterceptorProvider,
    { provide: APP_BASE_HREF, useValue: '/' },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
