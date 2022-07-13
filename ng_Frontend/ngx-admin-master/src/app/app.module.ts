import { PagesComponent } from './pages/pages.component';
/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ThemeModule } from './@theme/theme.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import {
  NbChatModule,
  NbDatepickerModule,
  NbDialogModule,
  NbMenuModule,
  NbSidebarModule,
  NbToastrModule,
  NbWindowModule,
} from '@nebular/theme';

import { TokenInterceptor } from './auth/token.interceptor';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { CommonModule } from '@angular/common';
import { CoreModule } from './@core/core.module';
import { SharedModule } from './pages/shared/shared.module';
import { LogoutComponent } from './pages/logout/logout.component';
import { CustomFormsModule } from 'ngx-custom-validators';
import { NgxSpinnerModule } from 'ngx-spinner';
import { TempSaveSampleComponent } from './pages/TempSaveSample/Sample.component';
import { SampleComponent } from './pages/Sample/Sample.component';
import { ApplyComponent } from './pages/Apply/Apply.component';
//_import保留字DD

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    HomeComponent,
    LoginComponent,
    LogoutComponent,
    TempSaveSampleComponent,
    SampleComponent,
ApplyComponent,
//_declarations保留字
  ],
  imports: [
    NgxSpinnerModule,
    CommonModule,
    BrowserModule,
    CustomFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    SharedModule,
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbDatepickerModule.forRoot(),
    NbDialogModule.forRoot(),
    NbWindowModule.forRoot(),
    NbToastrModule.forRoot(),
    NbChatModule.forRoot({
      messageGoogleMapKey: 'AIzaSyA_wNuCzia92MAmdLRzmqitRGvCF7wCZPY',
    }),
    CoreModule.forRoot(),
    ThemeModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },

  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
