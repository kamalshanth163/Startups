import { Component } from '@angular/core';
import { Router } from '@angular/router';
import axios from 'axios';
import { environment } from 'environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  showLoginForm: boolean = true;
  loginData: any = { email: '', password: '' };

  constructor(private router: Router) { }

  login() {
    axios.post(environment.apiUrl + '/founders/login', this.loginData)
      .then((response: any) => {
        if (response?.data?.token) {
          localStorage.setItem('startups-user', JSON.stringify(response.data));
          this.router.navigate(['/dashboard']);
        }
      })
      .catch((error: any) => {
        alert('Invalid Email or Password');
        console.error('Login failed:', error);
      });
  }

  ngOnInit() {
    localStorage.setItem('startups-user', JSON.stringify({}));
  }
}
