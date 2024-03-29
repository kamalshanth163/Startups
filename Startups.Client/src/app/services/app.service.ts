import { Injectable } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private sanitizer: DomSanitizer) { }

  formatDate(dateString: Date): string {
    if (!dateString) return '';

    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
  }

  sanitizeUrl(url: string): SafeUrl {
    if (url && !url.match(/^https?:\/\//i)) {
      url = `https://${url}`;
    }
    return this.sanitizer.bypassSecurityTrustUrl(url);
  }
}
