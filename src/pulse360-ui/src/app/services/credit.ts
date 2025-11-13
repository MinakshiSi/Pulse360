
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CreditService {
  private apiUrl = 'https://your-api.azurewebsites.net/api/credit'; // Replace with actual backend URL

  constructor(private http: HttpClient) {}

  getCreditSummary(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/summary`);
  }
}
