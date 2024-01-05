import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnInit {

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
