import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import axios from 'axios';
import { environment } from 'environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  showLoginForm: boolean = true;
  loginData: any = { email: '', password: '' };

  constructor(private http: HttpClient) {}

  login() {
    axios.post(environment.apiUrl + '/founders/login', this.loginData)
      .then((response: any) => {
        console.log('Login successful:', response.data);
      })
      .catch((error: any) => {
        console.error('Login failed:', error);
      });
  }
}
