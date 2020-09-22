import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { of } from 'rxjs';
import { map, retry } from 'rxjs/operators'

import { environment } from '../../environments/environment'
import Token from './token.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private TOKEN_KEY = 'token'
  private jwtHelper: JwtHelperService = new JwtHelperService()

  constructor(private http: HttpClient) { }

  public login(email: string, password: string) {
    const observer = this.http.post<Token>(`${environment.apiUrl}/token`, {
      email,
      password
    })
      .pipe(
        retry(3),
        map(({ token }) => {
          localStorage.setItem('token', token);
          return token;
        })
      )

    return observer
  }

  public logout() {
    localStorage.removeItem(this.TOKEN_KEY)
  }

  public getToken() {
    return localStorage.getItem(this.TOKEN_KEY)
  }

  public isAuthenticated() {
    const token = this.getToken()

    return token && !this.jwtHelper.isTokenExpired(token)
  }
}
