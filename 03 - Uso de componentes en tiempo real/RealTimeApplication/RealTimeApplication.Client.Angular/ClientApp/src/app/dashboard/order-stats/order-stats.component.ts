import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../../services/data/orders.service';
import { OrderModel } from 'src/app/models/order.model';

@Component({
  selector: 'app-order-stats',
  templateUrl: './order-stats.component.html',
  styleUrls: ['./order-stats.component.scss']
})
export class OrderStatsComponent implements OnInit {
  displayedColumns: string[] = ['FileImageIcon','OrderId','Name', 'Total', 'Comission','Description','Rating','Action'];
  orders:OrderModel[] = [];

  constructor(
    private ordersService: OrdersService
  ) { }

  ngOnInit(): void {
    this.list();
  }

  list() {
    this.ordersService.list().subscribe(orders => {
      this.orders = orders;
    });
  }
}
