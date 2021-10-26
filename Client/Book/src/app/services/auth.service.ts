import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  invalidLogin: boolean;
  private readonly apiURL = environment.apiURL;
  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  login(login: Login){
    this.http.post(this.apiURL+ '/Account/Login', login)
    .subscribe(data => {
      const token = (<any>data).token;
      localStorage.setItem("jwt", token); 
    }, err => {
      console.log(err);
      this.invalidLogin = false;
    })
  }
  logout(){
    localStorage.removeItem("jwt");
  }
  isAuthenticated(): boolean {
    const token = (<string>localStorage.getItem("jwt"));

    if(token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }else { 
      return false;
    }
  }
}

