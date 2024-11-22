import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import config from '../../auth_config.json';
import { catchError } from 'rxjs/operators';

import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  private baseUrl = 'http://localhost:3000/api/Labs/'; // URL вашого API

  solveLab(labEndpoint: string, inputText: string): Observable<any> {
    const apiUrl = this.baseUrl + labEndpoint;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json', // Вказуємо, що контент - це JSON
    });

    // Серіалізуємо текст, щоб передати його як JSON
    const body = JSON.stringify(inputText);

    return this.http.post<any>(apiUrl, body, { headers }).pipe(
      catchError((error) => {
        console.error('API error:', error);
        return throwError(() => new Error('Помилка при виклику API'));
      }),
    );
  }
}
