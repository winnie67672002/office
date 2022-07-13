import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { AutocompleteTag, Tag } from '../../model/tag';
import { User } from '../../model/user';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class TagService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/Tag`;
  constructor(
    http: HttpClient,
  ) {
    super(http);

  }

  getList(request: ShareRequest): Observable<ResponseBase<Tag[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<Tag[]>>(
      url,
      request,
      this.httpOptions);
  }

  getData(request: ShareRequest): Observable<ResponseBase<Tag>> {
    const url = `${this.baseUrl}/GetData`;
    return this.http.post<ResponseBase<Tag>>(
      url,
      request,
      this.httpOptions);
  }


  addData(request: Tag): Observable<ResponseBase<string>> {
    const url = `${this.baseUrl}/AddData`;
    return this.http.post<ResponseBase<string>>(
      url,
      request,
      this.httpOptions);
  }

  saveData(request: Tag): Observable<ResponseBase<string>> {
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

  getDefaultList(): Observable<ResponseBase<Tag[]>> {
    const request = new ShareRequest();
    request.PageIndex = 1;
    request.PageSize = 99999;
    const url = `${this.baseUrl}/GetDefaultList`;
    return this.http.post<ResponseBase<Tag[]>>(
      url,
      request,
      this.httpOptions);
  }

  getAutocompleteList(request: ShareRequest): Observable<ResponseBase<AutocompleteTag[]>> {
    const url = `${this.baseUrl}/GetAutocompleteList`;
    return this.http.post<ResponseBase<AutocompleteTag[]>>(
      url,
      request,
      this.httpOptions);
  }

  getAutocompleteByTagValueList(request: ShareRequest): Observable<ResponseBase<AutocompleteTag[]>> {
    const url = `${this.baseUrl}/GetAutocompleteByTagValueList`;
    return this.http.post<ResponseBase<AutocompleteTag[]>>(
      url,
      request,
      this.httpOptions);
  }
}
