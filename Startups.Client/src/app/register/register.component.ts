import { Component, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})

export class RegisterComponent {
  showRegisterForm: boolean = true;
  registerData: any = { name: '', email: '', password: '' };

  constructor(private http: HttpClient) {}

  register() {
    // Assuming sampleurl/register is your endpoint
    this.http.post('sampleurl/register', this.registerData)
      .subscribe(response => {
        // Handle registration success
        console.log('Registration successful');
      }, error => {
        // Handle registration error
        console.error('Registration failed:', error);
      });
  }

  toggleForms() {
    this.showRegisterForm = !this.showRegisterForm;
  }
}
