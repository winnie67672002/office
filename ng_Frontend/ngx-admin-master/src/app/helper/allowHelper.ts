import { filter } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { MenuAllow } from '../../model/menu';
import { Router } from '@angular/router';
import { EnumAllowType } from '../enum/enumAllowType';

@Injectable({ providedIn: 'root' })
export class AllowHelper {

  allow = [] as MenuAllow[];
  constructor(private router: Router) {


  }
  isCreate() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.Create).length > 0;
  }
  isUpdate() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.Update).length > 0;
  }
  isDelete() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.Delete).length > 0;
  }
  isRead() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.Read).length > 0;
  }
  isExcelImport() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.ExcelImport).length > 0;
  }
  isExcelExport() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.ExcelExport).length > 0;
  }
  isReport() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.Report).length > 0;
  }
  isApiImport() {
    this.getAllow();
    return this.allow.filter(x => this.router.url.indexOf(x.CPageUrl)
      !== -1 && x.CCompetenceType === EnumAllowType.ApiImport).length > 0;
  }

  getAllow() {
    const allowJson = localStorage.getItem('cdp_allow');
    if (allowJson !== null && allowJson !== '') {
      this.allow = JSON.parse(allowJson);
    }
  }
}
