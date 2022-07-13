import { BaseRequest } from './../../../../model/Request/baseRequest';
import { UserLog } from './../../../../model/userLog';
import { BaseComponent } from './../../base/baseComponent';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { SharedObservable } from '../../shared/shared.observable';
import { SharedService } from '../../../services/shared.service';
import { FunctionModel } from '../../../../model/function';
import { FormControl } from '@angular/forms';
import { ShareRequest } from '../../../../model/Request/shareRequest';
import { AllowHelper } from '../../../helper/allowHelper';

@Component({
  selector: 'ngx-logs-management',
  templateUrl: './logs-management.component.html',
  styleUrls: ['./logs-management.component.scss'],
})
export class LogsManagementComponent extends BaseComponent implements OnInit {

  userLogs = [] as UserLog[];
  functions = [] as FunctionModel[];

  request = new ShareRequest();
  baseRequest = new BaseRequest();

  constructor(
    private userService: UserService,
    private share: SharedObservable,
    private baseService: SharedService,
    protected allow: AllowHelper,
  ) {
    super(allow);

    this.share.SharedUserLog.subscribe(res => {
      this.userLogs = res;
    });
    this.share.SharedFunctionModel.subscribe(res => {
      this.functions = res;
    });

    this.request.DateStart = new Date();
    this.request.DateEnd = new Date();

    this.getUserLog();
    this.getFunction();
  }

  ngOnInit(): void {

  }

  getUserLog() {
    this.request.PageSize = this.pageSize;
    this.request.PageIndex = this.pageIndex;

    this.userService.getUserLog(this.request).subscribe(res => {
      this.userLogs = res.Entries;
      this.totalRecords = res.TotalItems;
      this.share.SetUserLog(this.userLogs);
    });
  }


  getFunction() {
    this.baseService.getFunction(this.baseRequest).subscribe(res => {
      this.functions = res.Entries;
      this.share.SetFunctionModel(this.functions);
    });
  }

}
