import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TagMemberAddRequest, TagMemberFilterRequest } from '../../model/Request/tagMemberRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { TagMember } from '../../model/tagMember';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class TagMemberService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/TagMember`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  getList(request: TagMemberFilterRequest): Observable<ResponseBase<TagMember[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<TagMember[]>>(
      url,
      request,
      this.httpOptions);
  }

  addData(request: TagMemberAddRequest): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }
}
