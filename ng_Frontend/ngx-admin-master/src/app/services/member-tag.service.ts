import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberTag } from '../../model/memberTag';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class MemberTagService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/MemberTag`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  getList(request: ShareRequest): Observable<ResponseBase<MemberTag[]>> {
    request.PageIndex = 1;
    request.PageSize = 99999;
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<MemberTag[]>>(
      url,
      request,
      this.httpOptions);
  }

  addData(request: MemberTag): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  saveData(request: MemberTag): Observable<ResponseBase<string>> {
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
