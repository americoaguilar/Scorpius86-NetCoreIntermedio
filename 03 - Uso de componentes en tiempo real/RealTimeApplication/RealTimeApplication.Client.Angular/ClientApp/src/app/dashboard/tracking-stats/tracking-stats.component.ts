import { Component, OnInit } from '@angular/core';
import {TrackingModel} from '../../models/tracking.Model';
import {TrackingsService}from '../../services/data/trackings.service';

@Component({
  selector: 'app-tracking-stats',
  templateUrl: './tracking-stats.component.html',
  styleUrls: ['./tracking-stats.component.scss']
})
export class TrackingStatsComponent implements OnInit {
  displayedColumns: string[] = ['FileImageIcon', 'Client', 'Order','TrackingId','Total', 'TrackingStatus','Action'];
  trackings:TrackingModel[] = [];

  constructor(
    private trackingsService:TrackingsService
  ) { }

  ngOnInit(): void {
    this.list();
  }

  list() {
    this.trackingsService.list().subscribe(trackings => {
      this.trackings = trackings;
    });
  }

}
