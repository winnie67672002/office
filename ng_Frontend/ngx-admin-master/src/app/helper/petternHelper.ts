import { filter } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { MenuAllow } from '../../model/menu';
import { Router } from '@angular/router';
import { EnumAllowType } from '../enum/enumAllowType';

@Injectable({ providedIn: 'root' })
export class PetternHelper {

  constructor() {
  }

  private _AccountPettern = '^[a-zA-Z0-9]{3,20}$';
  public get AccountPettern() {
    return this._AccountPettern;
  }
  public set AccountPettern(value) {
    this._AccountPettern = value;
  }
  private _PasswordPettern = '^[a-zA-Z0-9]{3,20}$';
  public get PasswordPettern() {
    return this._PasswordPettern;
  }
  public set PasswordPettern(value) {
    this._PasswordPettern = value;
  }
  private _MailPettern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  public get MailPettern() {
    return this._MailPettern;
  }
  public set MailPettern(value) {
    this._MailPettern = value;
  }
}
