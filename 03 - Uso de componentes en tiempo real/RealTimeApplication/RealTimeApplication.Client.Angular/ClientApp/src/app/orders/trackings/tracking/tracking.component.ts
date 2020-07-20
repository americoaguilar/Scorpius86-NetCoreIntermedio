import { Component, OnInit, Input } from '@angular/core';
import { TrackingsService } from 'src/app/services/data/trackings.service';
import { TrackingModel } from 'src/app/models/tracking.Model';
import { ActivatedRoute } from '@angular/router';
import { SignalRService } from '../../../services/signal-r/signal-r.service';
import { debug } from 'console';

@Component({
  selector: 'app-tracking',
  templateUrl: './tracking.component.html',
  styleUrls: ['./tracking.component.scss']
})
export class TrackingComponent implements OnInit {
  tracking: TrackingModel;
  trackingId = 0;
  isLoading = true;

  constructor(
    private route: ActivatedRoute,
    private trackingsService: TrackingsService,
    private signalRService: SignalRService
  ) { }

  ngOnInit(): void {
    this.trackingId = this.route.snapshot.params.trackingId;
    this.isLoading = true;
    this.getByTrackingId(this.trackingId);
    this.subscribeToEvents();
  }

  getByTrackingId(trackingId: number) {    
    this.trackingsService.getByTrackingId(trackingId).subscribe(tracking => {
      this.tracking = tracking;
      this.isLoading = false;
    });
  }

  private subscribeToEvents(): void {

    this.signalRService.onUpdateTracking.subscribe((tracking: TrackingModel) => {
      this.updateTracking(tracking);
    });
  }

  private updateTracking(tracking: TrackingModel) {
    this.getByTrackingId(tracking.TrackingId);
  }

}
