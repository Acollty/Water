import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { MemberRoutingModule } from './member-routing.module';
import { MemberComponent } from './member.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    MemberComponent
  ],
  imports: [
    SharedModule,
    MemberRoutingModule,
    NgbDatepickerModule
  ]
})
export class MemberModule { }
