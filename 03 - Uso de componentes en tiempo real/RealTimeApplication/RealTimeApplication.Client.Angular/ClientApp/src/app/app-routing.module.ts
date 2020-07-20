import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import {DashboardComponent} from './dashboard/dashboard.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';

import { SalesProgressComponent } from './dashboard/sales-progress/sales-progress.component';
import { WeeklyIncomeComponent } from './dashboard/weekly-income/weekly-income.component';
import { SalesChangeComponent } from './dashboard/sales-change/sales-change.component';
import { NotificationComponent } from './dashboard/notification/notification.component';
import { TrendingItemComponent } from './dashboard/trending-item/trending-item.component';
import { TrendComponent } from './dashboard/trend/trend.component';
import { SaleByCustomerComponent } from './dashboard/sale-by-customer/sale-by-customer.component';
import { LeadingProductComponent } from './dashboard/leading-product/leading-product.component';
import { OrderStatsComponent } from './dashboard/order-stats/order-stats.component';
import { TrackingStatsComponent } from './dashboard/tracking-stats/tracking-stats.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'orders/:orderId', loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule) },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: '**', pathMatch: 'full', redirectTo: '/dashboard' }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { useHash: true })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
  static components = [
      DashboardComponent,
      NavMenuComponent,

      SaleByCustomerComponent,
      SalesProgressComponent,
      LeadingProductComponent,
      WeeklyIncomeComponent,
      SalesChangeComponent,
      OrderStatsComponent,
      NotificationComponent,
      TrendingItemComponent,
      TrendComponent,
      TrackingStatsComponent,
      SaleByCustomerComponent,
  ]
}
