import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MassTransitHttpClientService {

  private baseUrl = `${environment.api}/upload-file`

  constructor(private http: HttpClient) { }

  uploadFileToAzure() {
    
  }
}
