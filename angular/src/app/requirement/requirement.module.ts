import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { RequirementRoutingModule } from './requirement-routing.module';
import { RequirementComponent } from './requirement.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap'; // add this line


@NgModule({
  declarations: [
    RequirementComponent
  ],
  imports: [
    SharedModule,
    RequirementRoutingModule,
    NgbDatepickerModule, // add this line
  ]
})
export class RequirementModule { }
