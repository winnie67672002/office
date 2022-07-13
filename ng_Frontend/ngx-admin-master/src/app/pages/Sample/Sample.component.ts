import { SampleGetListResponse } from '../../../model/Sample/SampleGetListResponse';
import { SampleGetListArg } from '../../../model/Sample/SampleGetListArg';
import { SampleGetDataResponse } from '../../../model/Sample/SampleGetDataResponse';
import { SampleGetDataArg } from '../../../model/Sample/SampleGetDataArg';
import { SampleSaveDataResponse } from '../../../model/Sample/SampleSaveDataResponse';
import { SampleSaveDataArg } from '../../../model/Sample/SampleSaveDataArg';
import { SampleRemoveDataResponse } from '../../../model/Sample/SampleRemoveDataResponse';
import { SampleRemoveDataArg } from '../../../model/Sample/SampleRemoveDataArg';
import { SampleService } from '../../services/Sample.service';
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

@Component({
  selector: 'ngx-Sample',
  templateUrl: './Sample.component.html',
  styleUrls: ['./Sample.component.scss'],
})
export class SampleComponent extends BaseComponent implements OnInit {

  // request = new ShareRequest();
  // userList = [] as User[];
  // user = new User();
  sampleGetListArg = new SampleGetListArg();
  sampleGetDataArg = new SampleGetDataArg();
  sampleRemoveDataArg = new SampleRemoveDataArg();
  SampleList = [] as SampleGetListResponse[];
  sample = new SampleSaveDataArg();

  //
  cTypeOptions = [
     { value: 'T1', text: '功能1' },
 { value: 'T2', text: '功能2' },
 { value: 'T3', text: '功能3' },
  ];


  cType2Options = [
     { value: 'T1', text: 'B功能1' },
 { value: 'T2', text: 'B功能2' },
 { value: 'T3', text: 'B功能3' },
  ];


  isNew = false;


  constructor(
    private dialogService: NbDialogService,
    private share: SharedObservable,
    private _SampleService: SampleService,
    private message: MessageService,
    private valid: ValidationHelper,
    protected allow: AllowHelper,
    private router: Router,
    private pettern: PetternHelper) {
    super(allow);

    // this.share.SharedSample.subscribe(res => {
    //   this.SampleList = res;
    // });

    this.getList();
  }

  ngOnInit(): void {

  }


  // 取得列表
  getList() {

    this.sampleGetListArg.PageSize = this.pageSize;
    this.sampleGetListArg.PageIndex = this.pageIndex;

    this._SampleService.GetList(this.sampleGetListArg).subscribe(res => {
      this.SampleList = res.Entries;
      this.totalRecords = res.TotalItems;
     // this.share.SetSample(this.SampleList);
    });
  }

  // 取得資料
  getData(arg: SampleGetDataArg) {
    this._SampleService.GetData(arg).subscribe(res => {
      this.sample = res.Entries;
    });
  }


  add(dialog: TemplateRef<any>) {
    this.sample = new SampleSaveDataArg();
    this.isNew = true;
    this.dialogService.open(dialog);
  }


  save(ref: any) {

    this.validation();
    if (this.valid.errorMessages.length > 0) {
      this.message.showErrorMSGs(this.valid.errorMessages);
      return;
    }

    
    this._SampleService.SaveData(this.sample).subscribe(res => {
      if (res.StatusCode === EnumStatusCode.Success) {
        this.message.showSucessMSG('執行成功');
        this.getList();
        ref.close();
      }
    });
    
  }

  remove(arg: SampleRemoveDataArg) {
    this._SampleService.RemoveData(arg).subscribe(res => {
      this.message.showSucessMSG('執行成功');
      this.getList();
    });
  }

  onDelete(data: SampleRemoveDataArg) {
    this.isNew = false;
    if (window.confirm('是否確定刪除?')) {
      this.remove(data);
    } else {
      return;
    }
  }

  onEdit(data: SampleGetDataArg, dialog: TemplateRef<any>) {
    this.isNew = false;
    this.getData(data);
    this.dialogService.open(dialog);
  }

  validation() {
    this.valid.clear();
    this.valid.required('[必填範例]', this.sample.cDescription);
this.valid.required('[下拉範例]', this.sample.cType);
this.valid.required('[下拉範例2]', this.sample.cType2);
    // this.valid.required('[帳號]', this.user.CAccount);
    // this.valid.pattern('[帳號]', this.user.CAccount, this.pettern.AccountPettern);
  
  }
   
  mapcTypeOptions(key) {
    const mapObj = this.cTypeOptions.filter(x => x.value === key);
    if (mapObj.length > 0)
      return mapObj[0].text;
    else
      return '';
  }

 
  mapcType2Options(key) {
    const mapObj = this.cType2Options.filter(x => x.value === key);
    if (mapObj.length > 0)
      return mapObj[0].text;
    else
      return '';
  }

}
