import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { PagesComponent } from './pages/pages.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { LogoutComponent } from './pages/logout/logout.component';
import { TempSaveSampleComponent } from './pages/TempSaveSample/Sample.component';
import { SampleComponent } from './pages/Sample/Sample.component';
import { ApplyComponent } from './pages/Apply/Apply.component';
//_import保留字

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  {
    path: '',
    component: PagesComponent,
    children: [

      { path: '', component: HomeComponent },
      { path: 'TempSaveSampleComponent', component: TempSaveSampleComponent },
      {
        path: 'pages',
        loadChildren: () => import('./pages/system-management/system-management.module')
          .then(mod => mod.SystemManagementModule),
      },
      {path: 'Sample', component: SampleComponent },
{path: 'itemapply', component: ApplyComponent },
//_declarations保留字
    ],
  },
  { path: '**', redirectTo: '/' },
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { onSameUrlNavigation: `reload` }),
    RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: [
  ],
})
export class AppRoutingModule {
}
