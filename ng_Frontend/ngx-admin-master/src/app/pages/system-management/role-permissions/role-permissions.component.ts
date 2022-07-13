import { UserGroupService } from './../../../services/user-group.service';
import { BaseComponent } from './../../base/baseComponent';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { MessageService } from '../../../services/message.service';
import { UserGroup } from '../../../../model/userGroup';
import { UserGroupFunction } from '../../../../model/userGroupFunction';
import { SharedObservable } from '../../shared/shared.observable';
import { ShareRequest } from '../../../../model/Request/shareRequest';
import { AllowHelper } from '../../../helper/allowHelper';
import { EnumStatusCode } from '../../../enum/enumStatusCode';
import { LocalDataSource } from 'ng2-smart-table';
import { ValidationHelper } from '../../../helper/validationHelper';

@Component({
  selector: 'ngx-role-permissions',
  templateUrl: './role-permissions.component.html',
  styleUrls: ['./role-permissions.component.scss'],
})
export class RolePermissionsComponent extends BaseComponent implements OnInit {

  userGroups = [] as UserGroup[];
  userGroupFunction = {} as UserGroupFunction;

  request = new ShareRequest();
  isNew = false;

  constructor(
    private dialogService: NbDialogService,
    private userGroupService: UserGroupService,
    private message: MessageService,
    private share: SharedObservable,
    protected allow: AllowHelper,
    private valid: ValidationHelper
  ) {
    super(allow);

    this.share.SharedUserGroup.subscribe(res => {
      this.userGroups = res;
    });
    this.share.SharedUserGroupFunction.subscribe(res => {
      this.userGroupFunction = res;
    });

    this.getList();
  }

  selectedItem = '';
  ngOnInit(): void {

  }

  getList() {
    this.request.PageSize = this.pageSize;
    this.request.PageIndex = this.pageIndex;

    this.userGroupService.getList(this.request).subscribe(res => {
      this.userGroups = res.Entries;
      this.totalRecords = res.TotalItems;
      this.share.SetUserGroup(this.userGroups);
    });
  }

  getFunction() {
    this.userGroupService.getData(this.request).subscribe(res => {
      this.userGroupFunction = res.Entries;
      this.share.SetUserGroupFunction(this.userGroupFunction);
    });
  }

  onDelete(data: UserGroup) {
    this.request.CId = data.CId;
    this.isNew = false;
    if (window.confirm('是否確定刪除?')) {
      this.remove();
    } else {
      return;
    }
  }

  onEdit(data: UserGroup, dialog: TemplateRef<any>) {
    this.request.CId = data.CId;
    this.isNew = false;
    this.getFunction();
    this.dialogService.open(dialog);
  }

  add(dialog: TemplateRef<any>) {
    this.isNew = true;
    this.request.CId = null;
    this.getFunction();
    this.dialogService.open(dialog);
  }

  save(ref: any) {

    this.validation();
    if (this.valid.errorMessages.length > 0) {
      this.message.showErrorMSGs(this.valid.errorMessages);
      return;
    }

    if (this.isNew) {
      this.userGroupService.addData(this.userGroupFunction).subscribe(res => {
        if (res.StatusCode === EnumStatusCode.Success) {
          this.message.showSucessMSG('執行成功');
          this.getList();
          ref.close();
        }
      });
    } else {
      this.userGroupService.saveData(this.userGroupFunction).subscribe(res => {
        if (res.StatusCode === EnumStatusCode.Success) {
          this.message.showSucessMSG('執行成功');
          this.getList();
          ref.close();
        }
      });
    }
  }

  remove() {
    this.userGroupService.removeData(this.request).subscribe(res => {
      this.message.showSucessMSG('執行成功');
      this.getList();
    });
  }

  validation() {
    this.valid.clear();
    this.valid.required('[角色名稱]', this.userGroupFunction.CName);
  }

}
