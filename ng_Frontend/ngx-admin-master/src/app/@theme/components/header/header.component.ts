import { ShareRequest } from './../../../../model/Request/shareRequest';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { NbMediaBreakpointsService, NbMenuService, NbSidebarService, NbThemeService } from '@nebular/theme';

import { UserData } from '../../../@core/data/users';
import { LayoutService } from '../../../@core/utils';
import { map, takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { decodeJwtPayload } from '@nebular/auth';
import { environment } from '../../../../environments/environment';
import { BusinessUnitService } from '../../../services/business-unit.service';
import { EnumStatusCode } from '../../../enum/enumStatusCode';
import { BusinessUnit } from '../../../../model/businessUnit';
import { MessageService } from '../../../services/message.service';



@Component({
  selector: 'ngx-header',
  styleUrls: ['./header.component.scss'],
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit, OnDestroy {


  private destroy$: Subject<void> = new Subject<void>();
  userPictureOnly: boolean = false;
  user: any;
  userName: string;

  buId: string;
  ownerBuId = `${environment.ownerBuId}`;
  businessUnits = [] as BusinessUnit[];
  selectBuId: string;

  request = {} as ShareRequest;
  currentTheme = 'default';

  constructor(private sidebarService: NbSidebarService,
    private menuService: NbMenuService,
    private themeService: NbThemeService,
    private userService: UserData,
    private layoutService: LayoutService,
    private breakpointService: NbMediaBreakpointsService,
    private router: Router,
    private service: BusinessUnitService,
    private message: MessageService) {
  }

  ngOnInit() {

    this.currentTheme = this.themeService.currentTheme;

    this.userService.getUsers()
      .pipe(takeUntil(this.destroy$))
      .subscribe((users: any) => this.user = users.nick);

    const { xl } = this.breakpointService.getBreakpointsMap();
    this.themeService.onMediaQueryChange()
      .pipe(
        map(([, currentBreakpoint]) => currentBreakpoint.width < xl),
        takeUntil(this.destroy$),
      )
      .subscribe((isLessThanXl: boolean) => this.userPictureOnly = isLessThanXl);

    this.themeService.onThemeChange()
      .pipe(
        map(({ name }) => name),
        takeUntil(this.destroy$),
      )
      .subscribe(themeName => this.currentTheme = themeName);

    const jwt = decodeJwtPayload(localStorage.getItem('cdp_token'));
    this.userName = jwt.UserName;
    this.buId = jwt.BuId;
    this.selectBuId = localStorage.getItem('cdp_buId');

    if (this.buId === this.ownerBuId) {
      this.service.getBusinessUnitList(this.request).subscribe(res => {
        if (res.StatusCode === EnumStatusCode.Success) {
          this.businessUnits = res.Entries;
        }
      });
    }
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  changeBuId(buId: string) {
    localStorage.setItem('cdp_buId', buId);
    this.message.showSucessMSG('執行成功');
    this.router.navigateByUrl('home');
  }

  toggleSidebar(): boolean {
    this.sidebarService.toggle(true, 'menu-sidebar');
    this.layoutService.changeLayoutSize();

    return false;
  }

  navigateHome() {
    this.router.navigateByUrl('home');
    return false;
  }

  logOut() {
    this.router.navigateByUrl('logout');
  }
}
