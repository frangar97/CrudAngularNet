import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './pages/list/list.component';
import { AddComponent } from './pages/add/add.component';
import { EditComponent } from './pages/edit/edit.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    ListComponent,
    AddComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    ListComponent,
    AddComponent,
    EditComponent,
  ]
})
export class EmployeeModule { }
