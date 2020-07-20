import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { OrderComponent } from './order/order.component';

const routes: Routes = [
  {
    path: '', component: OrdersComponent,
    children: [
      { path: 'trackings', loadChildren: () => import('./trackings/trackings.module').then(m => m.TrackingsModule) },
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
export class OrdersRoutingModule {
  static components = [
    OrdersComponent,
    OrderComponent
  ];
}
