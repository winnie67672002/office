import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FunctionModel } from '../../model/function';
import { BaseRequest } from '../../model/Request/baseRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})

export class SharedService extends ServiceBase {
  protected baseUrl = `${this.apiBaseUrl}/Base`;
  constructor(
    http: HttpClient,
  ) {
    super(http);

  }

  getFunction(request: BaseRequest): Observable<ResponseBase<FunctionModel[]>> {
    const url = `${this.baseUrl}/GetFunction`;
    return this.http.post<ResponseBase<FunctionModel[]>>(
      url,
      request,
      this.httpOptions);
  }

}
