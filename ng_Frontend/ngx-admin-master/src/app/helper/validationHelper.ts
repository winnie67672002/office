import { filter } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { MenuAllow } from '../../model/menu';
import { Router } from '@angular/router';
import { EnumAllowType } from '../enum/enumAllowType';
import { MessageService } from '../services/message.service';

@Injectable({ providedIn: 'root' })
export class ValidationHelper {

  errorMessages = [] as string[];

  constructor(private message: MessageService) {

  }

  required(name: string, value: any) {
    if (value == null || value === undefined) {
      this.addErrorMessage(name + ' 必填');
    }
    if (typeof (String)) {
      if (value === '') {
        this.addErrorMessage(name + ' 必填');
      }
    }
  }

  pattern(name: string, value: string, pattern: string) {
    const regex = new RegExp(pattern);
    if (regex.test(value) === false) {
      this.addErrorMessage(name + ' 格式錯誤');
    }
  }

  regExp(name: string, value: string, regEx: RegExp) {
    if (regEx.test(value) === false) {
      this.addErrorMessage(name + ' 格式錯誤');
    }
  }

  equal(name1: string, name2: string, value1: string, value2: string) {
    if (value1 !== value2) {
      this.addErrorMessage(name1 + ' 與 ' + name2 + ' 不相同');
    }
  }


  selected(name: string, value: string[]) {
    if (value.filter(x => x === '' || x === null || x === undefined).length > 0) {
      this.addErrorMessage(name + ' 尚未全部選擇');
    }
  }

  addErrorMessage(message: string) {
    this.errorMessages.push(message);
  }

  clear() {
    this.errorMessages = [];
  }
}
