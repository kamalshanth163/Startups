import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  showLoginForm: boolean = true;
  loginData: any = { email: '', password: '' };

  constructor(private http: HttpClient) {}

  login() {
    // Assuming sampleurl/login is your endpoint
    this.http.post('sampleurl/login', this.loginData)
      .subscribe(response => {
        // Handle login success
        console.log('Login successful');
      }, error => {
        // Handle login error
        console.error('Login failed:', error);
      });
  }

  toggleForms() {
    this.showLoginForm = !this.showLoginForm;
  }
}
