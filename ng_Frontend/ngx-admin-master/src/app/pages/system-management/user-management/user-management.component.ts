import { ShareRequest } from '../../../../model/Request/shareRequest';
import { BaseComponent } from './../../base/baseComponent';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { SharedObservable } from '../../shared/shared.observable';
import { User } from '../../../../model/user';
import { UserService } from '../../../services/user.service';
import { MessageService } from '../../../services/message.service';
import { AllowHelper } from '../../../helper/allowHelper';
import { UserGroupService } from '../../../services/user-group.service';
import { UserGroup } from '../../../../model/userGroup';
import { EnumStatusCode } from '../../../enum/enumStatusCode';
import { FormGroup, Validators } from '@angular/forms';
import { ValidationHelper } from '../../../helper/validationHelper';
import { TheadTitlesRowComponent } from 'ng2-smart-table/lib/components/thead/rows/thead-titles-row.component';
import { Router } from '@angular/router';
import { PetternHelper } from '../../../helper/petternHelper';

@Component({
  selector: 'ngx-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss'],
})
export class UserManagementComponent extends BaseComponent implements OnInit {

  request = new ShareRequest();
  userList = [] as User[];
  user = new User();
  userGroups = [] as UserGroup[];

  isNew = false;

  statusOptions = [
    { value: 0, label: '停用' },
    { value: 1, label: '啟用' },
  ];

  constructor(
    private dialogService: NbDialogService,
    private share: SharedObservable,
    private userService: UserService,
    private userGroupService: UserGroupService,
    private message: MessageService,
    protected allow: AllowHelper,
    private valid: ValidationHelper,
    private router: Router,
    private pettern: PetternHelper) {
    super(allow);

    this.share.SharedUser.subscribe(res => {
      this.userList = res;
    });
    this.share.SharedUserGroup.subscribe(res => {
      this.userGroups = res;
    });
    this.getList();
    this.getUserGroup();
  }

  ngOnInit(): void {

  }

  // 取得群組列表
  getUserGroup() {
    this.userGroupService.getList(this.request).subscribe(res => {
      this.userGroups = res.Entries;
      this.share.SetUserGroup(this.userGroups);
    });
  }

  // 取得使用者列表
  getList() {

    this.request.PageSize = this.pageSize;
    this.request.PageIndex = this.pageIndex;

    this.userService.getList(this.request).subscribe(res => {
      this.userList = res.Entries;
      this.totalRecords = res.TotalItems;
      this.share.SetUser(this.userList);
    });
  }

  // 取得使用者資料
  getData() {
    this.userService.getData(this.request).subscribe(res => {
      this.user = res.Entries;
    });
  }


  add(dialog: TemplateRef<any>) {
    this.user = new User();
    this.isNew = true;
    this.dialogService.open(dialog);
  }


  save(ref: any) {

    this.validation();
    if (this.valid.errorMessages.length > 0) {
      this.message.showErrorMSGs(this.valid.errorMessages);
      return;
    }

    if (this.isNew) {
      this.userService.addData(this.user).subscribe(res => {
        if (res.StatusCode === EnumStatusCode.Success) {
          this.message.showSucessMSG('執行成功');
          this.getList();
          ref.close();
        }
      });
    } else {
      this.userService.saveData(this.user).subscribe(res => {
        if (res.StatusCode === EnumStatusCode.Success) {
          this.message.showSucessMSG('執行成功');
          this.getList();
          ref.close();
        }
      });
    }

  }

  remove() {
    this.userService.removeData(this.request).subscribe(res => {
      this.message.showSucessMSG('執行成功');
      this.getList();
    });
  }

  onDelete(data: User) {
    this.request.CUserId = data.CUserId;
    this.isNew = false;
    if (window.confirm('是否確定刪除?')) {
      this.remove();
    } else {
      return;
    }
  }

  onEdit(data: User, dialog: TemplateRef<any>) {
    this.request.CUserId = data.CUserId;
    this.isNew = false;
    this.getData();
    this.dialogService.open(dialog);
  }

  validation() {
    this.valid.clear();
    this.valid.required('[帳號]', this.user.CAccount);
    this.valid.pattern('[帳號]', this.user.CAccount, this.pettern.AccountPettern);
    this.valid.required('[名稱]', this.user.CName);
    if (this.isNew) {
      this.valid.required('[密碼]', this.user.Password);
      this.valid.required('[確認密碼]', this.user.CfmPassword);
      this.valid.pattern('[確認密碼]', this.user.CfmPassword, this.pettern.PasswordPettern);
      this.valid.pattern('[密碼]', this.user.Password, this.pettern.PasswordPettern);
    }
    this.valid.equal('[密碼]', '[確認密碼]', this.user.Password, this.user.CfmPassword);
    this.valid.required('[權限]', this.user.ListUserGroup);
    this.valid.required('[狀態]', this.user.CStatus);
  }

}
