import { AllowHelper } from './../../helper/allowHelper';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnumStatusCode } from '../../enum/enumStatusCode';
import { MessageService } from '../../services/message.service';
import { BaseComponent } from '../base/baseComponent';
import { UserService } from '../../services/user.service';
import { LoginRequest } from '../../../model/Request/loginRequest';
import { ValidationHelper } from '../../helper/validationHelper';
import { decodeJwtPayload } from '@nebular/auth';
import { PetternHelper } from '../../helper/petternHelper';

@Component({
  selector: 'ngx-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  request = new LoginRequest();

  constructor(
    private router: Router,
    private service: UserService,
    private message: MessageService,
    private valid: ValidationHelper,
    protected allow: AllowHelper,
    private pettern: PetternHelper,
  ) {

  }

  ngOnInit(): void {
  }
  login() {
    this.validation();
    if (this.valid.errorMessages.length > 0) {
      this.message.showErrorMSGs(this.valid.errorMessages);
      return;
    }

    this.service.login(this.request).subscribe(
      res => {
        if (res.StatusCode === EnumStatusCode.Success) {
          const jwt = decodeJwtPayload(res.Entries);
          localStorage.setItem('cdp_token', res.Entries);
          localStorage.setItem('cdp_buId', jwt.BuId);
          this.message.showSucessMSG('登入成功');
          this.router.navigateByUrl('home');
        }
      },
    );
  }

  validation() {
    this.valid.clear();
    this.valid.required('[帳號]', this.request.Account);
    this.valid.pattern('[帳號]', this.request.Account, this.pettern.AccountPettern);
    this.valid.required('[密碼]', this.request.Password);
    this.valid.pattern('[密碼]', this.request.Password, this.pettern.PasswordPettern);
  }
}
