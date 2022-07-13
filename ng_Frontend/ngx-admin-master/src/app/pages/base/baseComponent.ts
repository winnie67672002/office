import { formatDate } from '@angular/common';
import { Injectable, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import * as moment from 'moment';
import { Menu } from '../../../model/menu';
import { AllowHelper } from '../../helper/allowHelper';
import { SharedObservable } from '../shared/shared.observable';

@Injectable()
export class BaseComponent implements OnInit {


  pageIndex = 1;
  pageSize = 10;
  totalRecords = 0;
  pageFirst = 0;

  isRead = this.allow.isRead();
  isCreate = this.allow.isCreate();
  isUpdate = this.allow.isUpdate();
  isDelete = this.allow.isDelete();
  isExcelImport = this.allow.isExcelImport();
  isExcelExport = this.allow.isExcelExport();

  constructor(
    protected allow: AllowHelper
  ) {

  }

  ngOnInit() {

  }

  getSubMenu(menu: Menu, routerUrl: string) {
    return menu.Menu.map(function (p) { return p.Child; })
      .reduce(function (a, b) { return a.concat(b); })
      .find(x => routerUrl.indexOf(x.CPageUrl) !== -1);
  }

  isNullOrEmpty(value: string) {
    if (value === undefined) {
      return true;
    }
    if (value == null) {
      return true;
    }
    if (value === '') {
      return true;
    }
    return false;
  }
}
