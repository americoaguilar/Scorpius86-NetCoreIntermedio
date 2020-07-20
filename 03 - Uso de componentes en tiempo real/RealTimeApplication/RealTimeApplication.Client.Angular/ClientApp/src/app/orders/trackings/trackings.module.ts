import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrackingsRoutingModule } from './trackings-routing.module';
import { SharedModule } from '../../shared/shared.module';



@NgModule({
  declarations: [TrackingsRoutingModule.components],
  imports: [
    CommonModule,
    SharedModule,
    TrackingsRoutingModule
  ]
})
export class TrackingsModule { }
