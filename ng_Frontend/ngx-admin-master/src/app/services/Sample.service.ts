
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SampleGetListResponse } from '../../model/Sample/SampleGetListResponse';
import { SampleGetListArg } from '../../model/Sample/SampleGetListArg';
import { SampleGetDataResponse } from '../../model/Sample/SampleGetDataResponse';
import { SampleGetDataArg } from '../../model/Sample/SampleGetDataArg';
import { SampleSaveDataResponse } from '../../model/Sample/SampleSaveDataResponse';
import { SampleSaveDataArg } from '../../model/Sample/SampleSaveDataArg';
import { SampleRemoveDataResponse } from '../../model/Sample/SampleRemoveDataResponse';
import { SampleRemoveDataArg } from '../../model/Sample/SampleRemoveDataArg';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class SampleService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/Sample`;
  constructor(
    http: HttpClient
  ) {
    super(http);
  }
  
  GetList(request: SampleGetListArg): Observable<ResponseBase<SampleGetListResponse[]>> {
    const url = `${this.baseUrl}/GetList`;
    return this.http.post<ResponseBase<SampleGetListResponse[]>>(
      url,
      request,
      this.httpOptions);
  }


  GetData(request: SampleGetDataArg): Observable<ResponseBase<SampleSaveDataArg>> {
    const url = `${this.baseUrl}/GetData`;
    return this.http.post<ResponseBase<SampleSaveDataArg>>(
      url,
      request,
      this.httpOptions);
  }


  SaveData(request: SampleSaveDataArg): Observable<ResponseBase<SampleSaveDataArg>> {
    const url = `${this.baseUrl}/SaveData`;
    return this.http.post<ResponseBase<SampleSaveDataArg>>(
      url,
      request,
      this.httpOptions);
  }


  RemoveData(request: SampleRemoveDataArg): Observable<ResponseBase<SampleRemoveDataResponse[]>> {
    const url = `${this.baseUrl}/RemoveData`;
    return this.http.post<ResponseBase<SampleRemoveDataResponse[]>>(
      url,
      request,
      this.httpOptions);
  }

}

