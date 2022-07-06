import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class ApiService {
  apiUrl: string = "/api"

  constructor(
    private http: HttpClient
  ) {

  }

  private formatErrors(error: any) {
    return  throwError(error.error);
  }

  get<T>(path: string, params: HttpParams = new HttpParams()): Observable<T> {
    return this.http.get<T>(`${this.apiUrl}${path}`, { params })
      .pipe(catchError(this.formatErrors));
  }

  put<T>(path: string, body: Object = {}): Observable<T> {
    return this.http.put<T>(
      `${this.apiUrl}${path}`,
      JSON.stringify(body)
    ).pipe(catchError(this.formatErrors));
  }

  post<T>(path: string, body: Object = {}, options?: any): Observable<T> {
    return this.http.post<T>(
      `${this.apiUrl}${path}`,
      JSON.stringify(body)
    ).pipe(catchError(this.formatErrors));
  }

  patch<T>(path: string, body: Object = {}): Observable<T> {
    return this.http.patch<T>(
      `${this.apiUrl}${path}`,
      JSON.stringify(body)
    ).pipe(catchError(this.formatErrors));
  }

  delete(path): Observable<any> {
    return this.http.delete(
      `${this.apiUrl}${path}`
    ).pipe(catchError(this.formatErrors));
  }
}