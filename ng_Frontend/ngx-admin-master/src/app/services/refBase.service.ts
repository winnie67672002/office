import { TaskLog } from './../../model/task';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RefBase } from '../../model/refBase';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { Task } from '../../model/task';
import { ServiceBase } from './service-base';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RefBaseService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/RefBase`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  getInfoList(request: ShareRequest): Observable<ResponseBase<RefBase[]>> {
    const url = `${this.baseUrl}/GetInfoList`;
    return this.http.post<ResponseBase<RefBase[]>>(
      url,
      request,
      this.httpOptions);
  }

  getInfoData(request: ShareRequest): Observable<ResponseBase<RefBase>> {
    const url = `${this.baseUrl}/GetInfoData`;
    return this.http.post<ResponseBase<RefBase>>(
      url,
      request,
      this.httpOptions);
  }


  addInfoData(request: RefBase): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddInfoData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  saveInfoData(request: RefBase): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/SaveInfoData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  removeInfoData(request: ShareRequest): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/RemoveInfoData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  reflashInfoToken(request: RefBase): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/ReflashInfoToken`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  getTaskList(request: ShareRequest): Observable<ResponseBase<Task>> {
    const url = `${this.baseUrl}/GetTaskList`;
    return this.http.post<ResponseBase<Task>>(
      url,
      request,
      this.httpOptions);
  }

  getTaskLog(request: ShareRequest): Observable<ResponseBase<TaskLog>> {
    const url = `${this.baseUrl}/GetDataList`;
    return this.http.post<ResponseBase<TaskLog>>(
      url,
      request,
      this.httpOptions);
  }

  uploadRefExcel(request: ShareRequest): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/UploadRefExcel`;

    const body: FormData = new FormData();
    body.append('DocFiles', request.File, request.File.name);
    body.append('RefBaseInfoId', request.RefBaseInfoId.toString());

    const headers = new HttpHeaders();
    headers.append('Content-Type', 'multipart/form-data');
    headers.append('Accept', 'application/json');

    return this.http.post<ResponseBase<string>>(
      url,
      body,
      { headers });

  }

  downloadRefExcel(): Observable<any> {
    const url = `${this.baseUrl}/DownloadRefExcel`;
    return this.http.get(
      url,
      { responseType: 'blob' });

  }

}
