import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { ChannelRoutingModule } from './channel-routing.module';
import { ChannelComponent } from './channel.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap'; // add this line


@NgModule({
  declarations: [
    ChannelComponent
  ],
  imports: [
    SharedModule,
    ChannelRoutingModule,
    NgbDatepickerModule
  ]
})
export class ChannelModule { }
