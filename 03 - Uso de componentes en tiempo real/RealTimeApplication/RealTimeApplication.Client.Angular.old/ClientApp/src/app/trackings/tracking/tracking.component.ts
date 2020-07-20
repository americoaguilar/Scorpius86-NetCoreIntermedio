import { Component, OnInit, Input } from '@angular/core';
import { TrackingsService } from 'src/app/services/data/trackings.service';
import { TrackingModel } from 'src/app/models/tracking.Model';

@Component({
  selector: 'app-tracking',
  templateUrl: './tracking.component.html',
  styleUrls: ['./tracking.component.scss']
})
export class TrackingComponent implements OnInit {
  @Input("TrackId") trackId:number;
  tracking:TrackingModel;

  constructor(
    private trackingsService:TrackingsService
  ) { }

  ngOnInit(): void {
    this.getByTrackingId(this.trackId);
  }

  getByTrackingId(trackingId:number){
    this.trackingsService.getByTrackingId(trackingId).subscribe(tracking=>{
      this.tracking = tracking;
    });
  }

}
