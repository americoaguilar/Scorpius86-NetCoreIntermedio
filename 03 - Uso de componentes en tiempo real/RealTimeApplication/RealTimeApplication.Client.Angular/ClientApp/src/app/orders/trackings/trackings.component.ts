import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.scss']
})
export class TrackingsComponent implements OnInit {
  orderId =0;
  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.orderId = this.route.snapshot.params.orderId;
  }

}
