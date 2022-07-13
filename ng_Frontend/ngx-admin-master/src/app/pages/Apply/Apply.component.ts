import { ApplyGetListResponse } from '../../../model/Apply/ApplyGetListResponse';
import { ApplyGetListArg } from '../../../model/Apply/ApplyGetListArg';
import { ApplyGetDataResponse } from '../../../model/Apply/ApplyGetDataResponse';
import { ApplyGetDataArg } from '../../../model/Apply/ApplyGetDataArg';
import { ApplySaveDataResponse } from '../../../model/Apply/ApplySaveDataResponse';
import { ApplySaveDataArg } from '../../../model/Apply/ApplySaveDataArg';
import { ApplyRemoveDataResponse } from '../../../model/Apply/ApplyRemoveDataResponse';
import { ApplyRemoveDataArg } from '../../../model/Apply/ApplyRemoveDataArg';
import { ApplyService } from '../../services/Apply.service';
import { BaseComponent } from '../base/baseComponent';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { MessageService } from '../../services/message.service';
import { EnumStatusCode } from '../../enum/enumStatusCode';
import { FormGroup, Validators } from '@angular/forms';
import { ValidationHelper } from '../../helper/validationHelper';
import { TheadTitlesRowComponent } from 'ng2-smart-table/lib/components/thead/rows/thead-titles-row.component';
import { Router } from '@angular/router';
import { PetternHelper } from '../../helper/petternHelper';
import { SharedObservable } from '../shared/shared.observable';
import { AllowHelper } from '../../helper/allowHelper';
import { decodeJwtPayload } from '@nebular/auth';

@Component({
  selector: 'ngx-Apply',
  templateUrl: './Apply.component.html',
  styleUrls: ['./Apply.component.scss'],
})
export class ApplyComponent extends BaseComponent implements OnInit {

  // request = new ShareRequest();
  // userList = [] as User[];
  // user = new User();
  applyGetListArg = new ApplyGetListArg();
  applyGetDataArg = new ApplyGetDataArg();
  applyRemoveDataArg = new ApplyRemoveDataArg();
  ApplyList = [] as ApplyGetListResponse[];
  apply = new ApplySaveDataArg();
  userName = "";
  nowTime= Date.now();
  //

  isNew = false;


  constructor(
    private dialogService: NbDialogService,
    private share: SharedObservable,
    private _ApplyService: ApplyService,
    private message: MessageService,
    private valid: ValidationHelper,
    protected allow: AllowHelper,
    private router: Router,
    private pettern: PetternHelper) {
    super(allow);

    // this.share.SharedApply.subscribe(res => {
    //   this.ApplyList = res;
    // });

    const jwt = decodeJwtPayload(localStorage.getItem('cdp_token'));
    this.userName = jwt.UserName;
    this.add();

  }

  ngOnInit(): void {

  }


  add() {
    this.apply = new ApplySaveDataArg();
    this.isNew = true;
  }


  save() {

    this.validation();
    if (this.valid.errorMessages.length > 0) {
      this.message.showErrorMSGs(this.valid.errorMessages);
      return;
    }


    this._ApplyService.SaveData(this.apply).subscribe(res => {
      if (res.StatusCode === EnumStatusCode.Success) {
        this.message.showSucessMSG('執行成功');
      }
    });

  }


  validation() {
    this.valid.clear();

    // this.valid.required('[帳號]', this.user.CAccount);
    // this.valid.pattern('[帳號]', this.user.CAccount, this.pettern.AccountPettern);

  }

}
