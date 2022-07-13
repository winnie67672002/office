import { AllowHelper } from './../../../helper/allowHelper';
import { BaseComponent } from './../../base/baseComponent';
import { Component, OnChanges, OnInit } from '@angular/core';
import { Menu } from '../../../../model/menu';
import { SharedObservable } from '../shared.observable';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.scss']
})
export class BreadcrumbComponent extends BaseComponent implements OnInit {

  masterMenu: string;
  subMenu: string;

  constructor(
    private share: SharedObservable,
    private router: Router,
    protected allow: AllowHelper) {
    super(allow);
  }

  ngOnInit(): void {

    this.share.SharedMenu.subscribe(res => {
      if (res.Menu !== undefined) {
        const subMenu = this.getSubMenu(res, this.router.url);
        if (subMenu !== undefined) {
          const masterMenu = res.Menu.find(x => x.CId === subMenu.CParentId);
          this.masterMenu = masterMenu.CName;
          this.subMenu = subMenu.CName;
        }
      }
    });
  }
}
