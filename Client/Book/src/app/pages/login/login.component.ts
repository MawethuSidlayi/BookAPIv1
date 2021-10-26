import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { Login } from 'src/app/models/login';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) { }
  login = {} as Login
  ngOnInit(): void {
  }
  loginForm = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl(''),
  });
  onLogin(): void {
    
    this.login.email = this.loginForm.value.userName
    this.login.password = this.loginForm.value.password
    this.authService.login(this.login);
    this.router.navigate([''])
  }
  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }
}
