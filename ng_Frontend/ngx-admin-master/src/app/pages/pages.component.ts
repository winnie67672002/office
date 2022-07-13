import { AllowHelper } from './../helper/allowHelper';
import { BaseComponent } from './base/baseComponent';
import { Component, OnInit } from '@angular/core';
import { NbMenuItem } from '@nebular/theme';
import { Menu, MenuAllow } from '../../model/menu';
import { UserService } from '../services/user.service';
import { SharedObservable } from './shared/shared.observable';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-pages',
  styleUrls: ['pages.component.scss'],
  template: `
    <ngx-one-column-layout>
      <nb-menu [items]="nbMenu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
    <ngx-spinner bdColor="rgba(0, 0, 0, 0.8)" size="medium" color="#fff" type="square-jelly-box" [fullScreen]="true"><p style="color: white"> Loading... </p></ngx-spinner>
  `,
})
export class PagesComponent extends BaseComponent implements OnInit {

  allowMenu = [] as MenuAllow[];
  nbMenu = [] as NbMenuItem[];
  menu = {} as Menu;
  constructor(
    private userService: UserService,
    private share: SharedObservable,
    protected allow: AllowHelper,
    private router: Router
  ) {
    super(allow);

    console.log('%cWelcome cdp', 'color: green; font-family: sans-serif; font-size: 4.5em; font-weight: bolder; text-shadow: #000 1px 1px;');

    this.share.SharedMenu.subscribe(res => {
      this.menu = res;
    });

    if (this.isNullOrEmpty(localStorage.getItem('cdp_token'))) {
      this.router.navigateByUrl('login');
      return;
    }

    this.userService.getMenu().subscribe(
      res => {
        let _menu: NbMenuItem[];
        _menu = [];

        res.Entries.Menu.filter(x => x.CIsMenu === true).forEach(item => {

          const _item = new NbMenuItem();
          _item.title = item.CName;
          _item.icon = item.CCssStyle;
          _item.link = item.CPageUrl;

          if (item.Child.length > 0) {
            _item.children = [];
            item.Child.forEach(subItem => {
              const _subItem = new NbMenuItem();
              _subItem.title = subItem.CName;
              _subItem.link = subItem.CPageUrl;
              _item.children.push(_subItem);

              // 取得權限
              subItem.Child.forEach(threeItem => {
                this.allowMenu.push({
                  CPageUrl: subItem.CPageUrl,
                  CCompetenceType: threeItem.CCompetenceType
                });
              });

            });
          }
          _menu.push(_item);
        });

        this.nbMenu = [..._menu];
        localStorage.setItem('cdp_allow', JSON.stringify(this.allowMenu));
        this.share.SetMenu(res.Entries);
      },
    );
  }

  ngOnInit(): void {

  }
}
