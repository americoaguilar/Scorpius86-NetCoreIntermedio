import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orderId = 0;
  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.orderId = this.route.snapshot.params.orderId;
  }

}
