import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import * as moment from 'moment';

@Injectable()
export class ServiceBase {
  protected httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  protected apiBaseUrl: string = `${environment.APIPath}`;

  constructor(protected http: HttpClient) { }

  convertUtcDate(data: Date) {
    return data;
  }

  getUtcDate() {
    return moment().utc;
  }

  // 實作moment
  convertLocalDate(data: Date) {
    return data;
  }

  formatDate(data: Date, format: string) {

  }

}
