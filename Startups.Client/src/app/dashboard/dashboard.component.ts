import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';


interface Startup {
  name: string;
  website: string;
}

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {

  startups: Startup[] = []; // Assuming you have startup data
  filteredStartups: Startup[] = [];
  searchTerm: string = '';

  constructor(private router: Router) {}

  ngOnInit() {
    // Retrieve the token from localStorage
    const token = localStorage.getItem('startups-api-token');

    if (!token) {
      // Redirect to login if there's no token
      this.router.navigate(['/login']);
    } else {
      // Verify token validity (check expiration)
      const isTokenValid = this.isTokenValid(token);

      if (!isTokenValid) {
        // Redirect to login if the token is invalid or expired
        this.router.navigate(['/login']);
      }
    }

    // Retrieve and set your startup data (replace this with your actual data retrieval logic)
    this.startups = [
      { name: 'Startup 1', website: 'https://www.startup1.com' },
      { name: 'Startup 2', website: 'https://www.startup2.com' },
      // Add more startups as needed
    ];

    // Filter startups based on search term
    this.filteredStartups = this.startups;
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
}
