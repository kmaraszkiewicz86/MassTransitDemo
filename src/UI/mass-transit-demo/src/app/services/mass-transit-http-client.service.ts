import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { FileBody } from '../models/file-body';
import { Result, ResultWithValue } from '../models/result';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { FileFromAzureResponse } from '../models/file-from-azure-response';

@Injectable({
  providedIn: 'root'
})
export class MassTransitHttpClientService {

  private uploadFileApiUrl = `${environment.api}/upload-file`;
  private getFileApiUrl = `${environment.api}/get-files`;

  constructor(private http: HttpClient) { }

  uploadFileToAzure(body: FileBody): Observable<Result> {
    return this.http.post<Result>(this.uploadFileApiUrl, body).pipe(
      catchError(error => {
        return throwError(() => new Error('Error occured when processing request'))
      })
    )
  }

  getFile(): Observable<ResultWithValue<FileFromAzureResponse>> {
    return this.http.get<ResultWithValue<FileFromAzureResponse>>(this.getFileApiUrl)
  }
}
