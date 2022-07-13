import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequest } from '../../model/Request/loginRequest';
import { Menu } from '../../model/menu';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';
import { User } from '../../model/user';
import { UserLog } from '../../model/userLog';
import { ShareRequest } from '../../model/Request/shareRequest';


@Injectable({
  providedIn: 'root',
})
export class UserService extends ServiceBase {
  protected baseUrl = `${this.apiBaseUrl}/User`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  login(request: LoginRequest): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/UserLogin`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  getMenu(): Observable<ResponseBase<Menu>> {
    const url = `${this.baseUrl}/GetMenu`;
    return this.http.post<ResponseBase<Menu>>(
      url,
      this.httpOptions);
  }

  getList(request: ShareRequest): Observable<ResponseBase<User[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<User[]>>(
      url,
      request,
      this.httpOptions);
  }

  getData(request: ShareRequest): Observable<ResponseBase<User>> {
    const url = `${this.baseUrl}/GetData`;
    return this.http.post<ResponseBase<User>>(
      url,
      request,
      this.httpOptions);
  }

  addData(request: User): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  saveData(request: User): Observable<ResponseBase<string>> {
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

  getUserLog(request: ShareRequest): Observable<ResponseBase<UserLog[]>> {
    const url = `${this.baseUrl}/GetUserLog`;
    return this.http.post<ResponseBase<UserLog[]>>(
      url,
      request,
      this.httpOptions);
  }
}
