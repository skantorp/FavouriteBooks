import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { AuthResult } from '../models/auth.result';
import { environment } from './../../environments/environment';
@Injectable()
export class AuthService {
  constructor(private http: HttpClient, private router: Router) {}

  login(username: string, password: string) {
    let apiUrl = environment.apiUrl;

    return this.http
      .post<AuthResult>(apiUrl + '/auth', { username, password })
      .pipe(
        tap((response) => {
          this.setSession(response);
          response.success = true;
        }),
        catchError((error) => {
          console.log('Wrong username or password');
          return of([]);
        })
      );
  }

  private setSession(authResult: AuthResult) {
    localStorage.setItem('token', authResult.token);
    localStorage.setItem('expires', authResult.expires.toString());
    localStorage.setItem('userName', authResult.name);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('expires');
    localStorage.removeItem('userName');
    this.router.navigate(['login']);
  }

  isTokenValid(): boolean {
    const token = localStorage.getItem('token');
    const expires = Date.parse(localStorage.getItem('expires') || '');

    return !!(token && expires > new Date().getTime());
  }
}
