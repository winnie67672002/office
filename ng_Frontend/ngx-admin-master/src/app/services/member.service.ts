import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../../model/member';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class MemberService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/Member`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  getList(request: ShareRequest): Observable<ResponseBase<Member[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<Member[]>>(
      url,
      request,
      this.httpOptions);
  }

  getData(request: ShareRequest): Observable<ResponseBase<Member>> {
    const url = `${this.baseUrl}/GetData`;
    return this.http.post<ResponseBase<Member>>(
      url,
      request,
      this.httpOptions);
  }

  addData(request: Member): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  saveData(request: Member): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/SaveData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  removeData(request: ShareRequest): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/RemoveData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }
}
