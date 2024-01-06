import { Component } from '@angular/core';
import { Router } from '@angular/router';
import axios from 'axios';
import { environment } from 'environment';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})

export class RegisterComponent {
  showRegisterForm: boolean = true;
  registerData: any = { name: '', email: '', password: '' };

  constructor(private router: Router) { }

  register() {
    axios.post(environment.apiUrl + '/founders/register', this.registerData)
      .then((response: any) => {
        if (response?.data?.token) {
          localStorage.setItem('startups-user', JSON.stringify(response.data));
          this.router.navigate(['/dashboard']);
        }
      })
      .catch((error: any) => {
        console.error('Registration failed:', error);
      });
  }

  ngOnInit() {
    localStorage.setItem('startups-user', JSON.stringify({}));
  }
}
