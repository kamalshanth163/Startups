import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import axios from 'axios';
import { environment } from 'environment';
import { Startup, Founder } from '../interfaces';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})

export class DashboardComponent implements OnInit {

  startups: Startup[] = []; // Assuming you have startup data
  filteredStartups: Startup[] = [];
  searchTerm: string = '';
  loggedUser: Founder = {
    id: '',
    name: '',
    email: '',
    token: ''
  };
  appService: AppService;

  constructor(private router: Router, private _appService: AppService) {
    var loggedUserData = localStorage.getItem('startups-user');
    if (loggedUserData !== null) this.loggedUser = JSON.parse(loggedUserData);
    this.appService = _appService;
  }

  ngOnInit() {
    if (!this.loggedUser.token) {
      // Redirect to login if there's no token
      this.router.navigate(['/login']);
    } else {
      // Verify token validity (check expiration)
      const isTokenValid = this.isTokenValid(this.loggedUser.token);

      if (!isTokenValid) {
        // Redirect to login if the token is invalid or expired
        this.router.navigate(['/login']);
      }
    }

    // Get all startups and set data
    this.getAllStartups();
  }

  getAllStartups() {
    var token = this.loggedUser.token;
    if (token) {
      axios.get(environment.apiUrl + '/startups', {
        headers: {
          Authorization: `Bearer ${token}`
        }
      })
        .then((response: any) => {
          this.startups = response.data;
          this.filteredStartups = response.data;
          console.log(this.startups);
        })
        .catch((error: any) => {
          console.error('Failed:', error);
        });
    }
  }

  redirectToStartup(startupId: string): void {
    console.log(startupId);
    this.router.navigate(['/startup', startupId]);
  }

  // Filtering function based on search term
  filterStartups() {
    this.filteredStartups = this.startups.filter((startup) =>
      startup.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  // Verify JWT token validation
  private isTokenValid(token: string): boolean {
    const helper = new JwtHelperService();
    const decodedToken = helper.decodeToken(token);
    const expirationDate = helper.getTokenExpirationDate(token);
    const isExpired = helper.isTokenExpired(token);
    return !isExpired;
  }

  // Logout user
  logout(): void {
    this.router.navigate(['/login']);
  }
}
