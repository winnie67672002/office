import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Report } from '../../model/report';
import { ShareRequest } from '../../model/Request/shareRequest';
import { ResponseBase } from '../../model/ResponseBase';
import { ServiceBase } from './service-base';

@Injectable({
  providedIn: 'root'
})
export class ReportService extends ServiceBase {

  protected baseUrl = `${this.apiBaseUrl}/Report`;
  constructor(
    http: HttpClient
  ) {
    super(http);

  }

  getReportURL(request: ShareRequest): Observable<ResponseBase<Report>> {
    const url = `${this.baseUrl}/GetReportURL`;
    return this.http.post<ResponseBase<Report>>(
      url,
      request,
      this.httpOptions);
  }

  // 人營銷售漏斗分析
  getSalesFunnelReport(request: ShareRequest): Observable<ResponseBase<Report>> {
    const url = `${this.baseUrl}/GetSalesFunnelReport`;
    return this.http.post<ResponseBase<Report>>(
      url,
      request,
      this.httpOptions);
  }

  // 人群特徵分析
  getPopFeatureReport(request: ShareRequest): Observable<ResponseBase<Report>> {
    const url = `${this.baseUrl}/GetPopFeatureReport`;
    return this.http.post<ResponseBase<Report>>(
      url,
      request,
      this.httpOptions);
  }

  // 廣告效果分析
  getAdvertisingEffectReport(request: ShareRequest): Observable<ResponseBase<Report>> {
    const url = `${this.baseUrl}/GetAdvertisingEffectReport`;
    return this.http.post<ResponseBase<Report>>(
      url,
      request,
      this.httpOptions);
  }

  // 渠道訂單分析
  getChannelOrderReport(request: ShareRequest): Observable<ResponseBase<Report>> {
    const url = `${this.baseUrl}/GetChannelOrderReport`;
    return this.http.post<ResponseBase<Report>>(
      url,
      request,
      this.httpOptions);
  }

  // 獨特性及受眾數分布圖
  getUniqueRespondentReport(request: ShareRequest): Observable<ResponseBase<Report>> {
    const url = `${this.baseUrl}/GetUniqueRespondentReport`;
    return this.http.post<ResponseBase<Report>>(
      url,
      request,
      this.httpOptions);
  }
}
