import { LogsManagementComponent } from './logs-management/logs-management.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RolePermissionsComponent } from './role-permissions/role-permissions.component';


const routes: Routes = [

  { path: 'role-permissions', component: RolePermissionsComponent},
  { path: 'user-management', component: UserManagementComponent},
  { path: 'logs-management', component: LogsManagementComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SystemManagementRoutingModule { }
