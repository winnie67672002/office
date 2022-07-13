
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApplyGetListResponse } from '../../model/Apply/ApplyGetListResponse';
import { ApplyGetListArg } from '../../model/Apply/ApplyGetListArg';
import { ApplyGetDataResponse } from '../../model/Apply/ApplyGetDataResponse';
import { ApplyGetDataArg } from '../../model/Apply/ApplyGetDataArg';
import { ApplySaveDataResponse } from '../../model/Apply/ApplySaveDataResponse';
import { ApplySaveDataArg } from '../../model/Apply/ApplySaveDataArg';
import { ApplyRemoveDataResponse } from '../../model/Apply/ApplyRemoveDataResponse';
import { ApplyRemoveDataArg } from '../../model/Apply/ApplyRemoveDataArg';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class ApplyService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/Apply`;
  constructor(
    http: HttpClient
  ) {
    super(http);
  }
  
  GetList(request: ApplyGetListArg): Observable<ResponseBase<ApplyGetListResponse[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<ApplyGetListResponse[]>>(
      url,
      request,
      this.httpOptions);
  }


  GetData(request: ApplyGetDataArg): Observable<ResponseBase<ApplySaveDataArg>> {
    const url = `${this.baseUrl}/GetData`;
    return this.http.post<ResponseBase<ApplySaveDataArg>>(
      url,
      request,
      this.httpOptions);
  }


  SaveData(request: ApplySaveDataArg): Observable<ResponseBase<ApplySaveDataArg>> {
    const url = `${this.baseUrl}/SaveData`;
    return this.http.post<ResponseBase<ApplySaveDataArg>>(
      url,
      request,
      this.httpOptions);
  }


  RemoveData(request: ApplyRemoveDataArg): Observable<ResponseBase<ApplyRemoveDataResponse[]>> {
    const url = `${this.baseUrl}/RemoveData`;
    return this.http.post<ResponseBase<ApplyRemoveDataResponse[]>>(
      url,
      request,
      this.httpOptions);
  }

}

