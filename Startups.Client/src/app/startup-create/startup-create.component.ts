import { Component } from '@angular/core';
import axios from 'axios';
import { environment } from 'environment';
import { Founder, Startup } from '../interfaces';
import { AppService } from '../services/app.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-startup-create',
  templateUrl: './startup-create.component.html',
})
export class StartupCreateComponent {

  startup: Startup = {
    id: '',
    name: '',
    businessDomain: '',
    description: '',
    grossSales: 0,
    netSales: 0,
    businessStartDate: new Date(),
    website: '',
    businessLocation: '',
    employeeCount: 0,
    founderId: '',
    founderName: '',
    created: '',
    updated: ''
  };
  loggedUser: Founder = {
    id: '',
    name: '',
    email: '',
    token: ''
  };
  token: string = "";
  appService: AppService;

  constructor(private router: Router, private route: ActivatedRoute, private _appService: AppService) {
    var loggedUserData = localStorage.getItem('startups-user');
    if (loggedUserData !== null) this.loggedUser = JSON.parse(loggedUserData);
    this.token = this.loggedUser.token;
    this.appService = _appService;
  }

  createStartup(): void {
    if (this.token) {
      var newStartup = this.startup;
      newStartup.founderId = this.loggedUser.id;

      axios.post(`${environment.apiUrl}/startups`, this.startup, {
        headers: {
          Authorization: `Bearer ${this.token}`
        }
      })
        .then((response: any) => {
          alert("Startup has created successfully!");
        })
        .catch((error: any) => {
          console.error('Failed:', error);
        });

    }
  }
}
