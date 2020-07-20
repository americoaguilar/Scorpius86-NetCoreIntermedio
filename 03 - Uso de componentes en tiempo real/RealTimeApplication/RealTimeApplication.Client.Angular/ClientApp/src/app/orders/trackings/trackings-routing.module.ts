import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { TrackingsComponent } from './trackings.component';
import { TrackingComponent } from './tracking/tracking.component';

const routes: Routes = [
  {
    path: '', component: TrackingsComponent,
    children: [
      { path: ':trackingId', component: TrackingComponent },
      { path: '**', redirectTo: '' }
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class TrackingsRoutingModule {
  static components = [
    TrackingsComponent,
    TrackingComponent
  ];
}
