import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  NbButtonModule, NbCardModule, NbCheckboxModule, NbFormFieldModule,
  NbInputModule, NbLayoutModule, NbSelectModule, NbTableModule,
  NbTabsetModule, NbTreeGridModule, NbRadioModule, NbIconModule,
  NbDatepickerModule,
  NbTagModule,
  NbAutocompleteModule
} from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PaginationComponent } from './pagination/pagination.component';
import { ThemeModule } from '../../@theme/theme.module';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { DefaultTagAutoCompleteComponent } from './default-tag-auto-complete/default-tag-auto-complete.component';
import { TagInputDirectiveComponent } from './tag-input-directive/tag-input-directive.component';

@NgModule({
  declarations: [
    PaginationComponent,
    BreadcrumbComponent,
    DefaultTagAutoCompleteComponent,
    TagInputDirectiveComponent,
  ],
  imports: [
    CommonModule,
    NbCardModule,
    NgbModule,
    FormsModule,
    NbLayoutModule,
    NbCheckboxModule,
    NbInputModule,
    NbButtonModule,
    NbSelectModule,
    NbTableModule,
    NbTabsetModule,
    NbFormFieldModule,
    NbTreeGridModule,
    Ng2SmartTableModule,
    NbRadioModule,
    NbEvaIconsModule,
    NbIconModule,
    NbDatepickerModule,
    NgbModule,
    ThemeModule,
    NbTagModule,
    NbAutocompleteModule,
  ],
  exports: [
    FormsModule,
    NbLayoutModule,
    NbCardModule,
    NbCheckboxModule,
    NbInputModule,
    NbButtonModule,
    NbSelectModule,
    NbTableModule,
    NbTabsetModule,
    NbFormFieldModule,
    NbTreeGridModule,
    Ng2SmartTableModule,
    NbRadioModule,
    NbEvaIconsModule,
    NbIconModule,
    NbDatepickerModule,
    NgbModule,
    ThemeModule,
    NbTagModule,
    NbAutocompleteModule,

    // 自製Component
    BreadcrumbComponent,
    PaginationComponent,
    DefaultTagAutoCompleteComponent,
    TagInputDirectiveComponent
  ]
})
export class SharedModule { }
