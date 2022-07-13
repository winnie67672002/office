import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BusinessUnit } from '../../model/businessUnit';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class BusinessUnitService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/BusinessUnit`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  getBusinessUnitList(request: ShareRequest): Observable<ResponseBase<BusinessUnit[]>> {
    const url = `${this.baseUrl}/GetBusinessUnitList`;
    return this.http.post<ResponseBase<BusinessUnit[]>>(
      url,
      request,
      this.httpOptions);
  }

}
