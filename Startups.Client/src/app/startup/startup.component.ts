import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import axios from 'axios';
import { Startup, Founder } from '../interfaces';
import { environment } from 'environment';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-startup',
  templateUrl: './startup.component.html',
})
export class StartupComponent implements OnInit {
  startupId: string = '';
  startup: Startup = {
    id: '',
    name: '',
    businessDomain: '',
    description: '',
    grossSales: 0,
    netSales: 0,
    businessStartDate: '',
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

  constructor(private route: ActivatedRoute, private _appService: AppService) {
    var loggedUserData = localStorage.getItem('startups-user');
    if (loggedUserData !== null) this.loggedUser = JSON.parse(loggedUserData);
    this.token = this.loggedUser.token;
    this.appService = _appService;
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.startupId = params['id'];
      this.getStartupById();
    });
  }

  getStartupById() {
    if (this.token) {
      axios.get(`${environment.apiUrl}/startups/id?id=${this.startupId}`, {
        headers: {
          Authorization: `Bearer ${this.token}`
        }
      })
        .then((response: any) => {
          this.startup = response.data;
        })
        .catch((error: any) => {
          console.error('Failed:', error);
        });
    }
  }

  saveStartup(): void {
    // Implement logic to save startup data using Axios POST request
    // axios.post(...);
  }

  isEditable(): boolean {
    return this.loggedUser.id === this.startup.founderId;
  }

  deleteStartup(): void {
    if (this.isEditable()) {
      axios.delete(`${environment.apiUrl}/startups/${this.startup.id}`, {
        headers: {
          Authorization: `Bearer ${this.token}`
        }
      })
        .then((response: any) => {
          console.log('Deleted:', response.data);
        })
        .catch((error: any) => {
          console.error('Failed:', error);
        });
    } else {
      console.log('You do not have permission to delete this startup.');
    }
  }
}
