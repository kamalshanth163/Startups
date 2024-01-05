import { Component, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import axios from 'axios';
import { environment } from '../../../environment';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})

export class RegisterComponent {
  showRegisterForm: boolean = true;
  registerData: any = { name: '', email: '', password: '' };

  constructor(private http: HttpClient) {}

  register() {
    axios.post(environment.apiUrl + '/founders/register', this.registerData)
      .then((response: any) => {
        console.log('Registration successful:', response.data);
      })
      .catch((error: any) => {
        console.error('Registration failed:', error);
      });
  }
}
