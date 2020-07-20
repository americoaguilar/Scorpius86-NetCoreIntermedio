import { Component, OnInit } from '@angular/core';
import {TrackingModel} from '../../models/tracking.Model';
import {TrackingsService}from '../../services/data/trackings.service';
import { SignalRService } from '../../services/signal-r/signal-r.service';

@Component({
  selector: 'app-tracking-stats',
  templateUrl: './tracking-stats.component.html',
  styleUrls: ['./tracking-stats.component.scss']
})
export class TrackingStatsComponent implements OnInit {
  displayedColumns: string[] = ['FileImageIcon', 'Client', 'Order','TrackingId','Total', 'TrackingStatus','Action'];
  trackings:TrackingModel[] = [];

  constructor(
    private trackingsService: TrackingsService,
    private signalRService: SignalRService
  ) { }

  ngOnInit(): void {
    this.list();
    this.subscribeToEvents();
  }

  list() {
    this.trackingsService.list().subscribe(trackings => {
      this.trackings = trackings;
    });
  }

  private subscribeToEvents(): void {

    this.signalRService.onUpdateTracking.subscribe((tracking: TrackingModel) => {
      this.updateTracking(tracking);
    });
  }

  private updateTracking(tracking: TrackingModel) {
    this.list();
  }

}
