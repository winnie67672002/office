import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { UserGroup } from '../../model/userGroup';
import { UserGroupFunction } from '../../model/userGroupFunction';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class UserGroupService extends ServiceBase {
  protected baseUrl = `${this.apiBaseUrl}/UserGroup`;
  constructor(
    http: HttpClient,
  ) {
    super(http);

  }

  getList(request: ShareRequest): Observable<ResponseBase<UserGroup[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<UserGroup[]>>(
      url,
      request,
      this.httpOptions);
  }

  getData(request: ShareRequest): Observable<ResponseBase<UserGroupFunction>> {
    const url = `${this.baseUrl}/GetData`;
    return this.http.post<ResponseBase<UserGroupFunction>>(
      url,
      request,
      this.httpOptions);
  }

  addData(request: UserGroupFunction): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  saveData(request: UserGroupFunction): Observable<ResponseBase<string>> {
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
