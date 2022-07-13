import { StateService } from './../@core/utils/state.service';
import { MessageService } from './../services/message.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse,
  HttpHandler,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
// import { AccountService } from '../services/account.service';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
@Injectable({ providedIn: 'root' })
export class TokenInterceptor implements HttpInterceptor {
  constructor(
    // private accountService: AccountService,
    private baseHelper: MessageService,
    private router: Router,
    private spinner: NgxSpinnerService
  ) { }
  LoadingQue = [];
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {

    const token = localStorage.getItem('cdp_token');
    if (token !== null && token !== undefined && token !== '') {
      request = request.clone(
        ({
          setHeaders: {
            Authorization: `Bearer ${localStorage.getItem('cdp_token')}`,
            BuId: localStorage.getItem('cdp_buId')
          },
        }),
      );
    }

    if (request.url.indexOf('GetAutocompleteList') === -1
      && request.url.indexOf('GetAutocompleteByTagValueList') === -1
    ) {
      this.spinner.show();
      this.LoadingQue.push(request);
    }

    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          this.LoadingQue.pop();
          this.spinner.hide();

          if (event.body.StatusCode > 0) {
            this.baseHelper.showErrorMSG(event.body.Message);
          }
        }
        return event;
      })
      ,
      catchError((error: HttpErrorResponse) => {
        this.spinner.hide();
        if (error.status === 401) {
          this.baseHelper.showErrorMSG('請先登入');
          this.router.navigateByUrl('login');
        } else if (error.status === 403) {
          this.baseHelper.showErrorMSG('權限不足');
          this.router.navigateByUrl('home');
        } else {
          this.baseHelper.showErrorMSG(error.statusText);
        }
        return throwError(error);
      }),
    );
  }
}
