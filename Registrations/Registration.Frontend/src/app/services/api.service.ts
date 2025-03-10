import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class RegistrationService {
  private apiUrl = 'https://localhost:7009';

  constructor(private http: HttpClient) {}

  getRegistrations(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/registration`);
  }

  getSocialMediaPlatforms(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/socialmedia`);
  }

  addRegistration(registration: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/registration`, registration);
  }
}
