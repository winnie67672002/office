import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SystemManagementRoutingModule } from './system-management-routing.module';
import { RolePermissionsComponent } from './role-permissions/role-permissions.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { LogsManagementComponent } from './logs-management/logs-management.component';
import { NbCardModule } from '@nebular/theme';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    RolePermissionsComponent,
    UserManagementComponent,
    LogsManagementComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    SystemManagementRoutingModule,
  ]
})
export class SystemManagementModule { }
