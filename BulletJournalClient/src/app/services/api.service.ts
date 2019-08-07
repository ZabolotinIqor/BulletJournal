import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http';
import {environment} from '../Shared/environment';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ApiService {


  constructor(private httpClient: HttpClient) { }
  private apiUrl: string = environment.apiEndpoint;

  static getFullUrl(url: string, apiUrl: string) {
    return `${apiUrl}${url}`;
  }
  get<T>(
    url: string,
    options?: {
      headers?:
        | HttpHeaders
        | {
        [header: string]: string | string[];
      };
      observe?: 'body';
      params?:
        | HttpParams
        | {
        [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    },
    apiUrl = this.apiUrl
  ): Observable<T> {
    return this.httpClient.get<T>(ApiService.getFullUrl(url, apiUrl), options || undefined);
  }
  post<T>(
    url: string,
    requestBody: any | null,
    options?: {
      headers?:
        | HttpHeaders
        | {
        [header: string]: string | string[];
      };
      observe?: 'body';
      params?:
        | HttpParams
        | {
        [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    },
    apiUrl = this.apiUrl
  ): Observable<T> {
    return this.httpClient.post<T>(ApiService.getFullUrl(url, apiUrl), requestBody, options || undefined);
  }

  put<T>(
    url: string,
    requestBody: any | null,
    options?: {
      headers?:
        | HttpHeaders
        | {
        [header: string]: string | string[];
      };
      observe?: 'body';
      params?:
        | HttpParams
        | {
        [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    },
    apiUrl = this.apiUrl
  ): Observable<T> {
    return this.httpClient.put<T>(ApiService.getFullUrl(url, apiUrl), requestBody, options || undefined);
  }

  delete<T>(
    url: string,
    elementId?: string | number,
    apiUrl = this.apiUrl
  ) {
    return this.httpClient.delete<T>(ApiService.getFullUrl(`${url}`, apiUrl));
  }

  downloadFileServer(downloadLink: string) {
    return this.httpClient.get(downloadLink, {responseType: 'blob'});
  }
  postFormData<T>(
    url: string,
    formData: FormData,
    apiUrl = this.apiUrl
  ): Observable<T> {
    return this.httpClient.post<T>(ApiService.getFullUrl(url, apiUrl), formData);
  }
}
