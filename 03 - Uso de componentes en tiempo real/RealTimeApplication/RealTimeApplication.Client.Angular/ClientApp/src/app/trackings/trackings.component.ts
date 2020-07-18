import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-trackings',
  templateUrl: './trackings.component.html',
  styleUrls: ['./trackings.component.scss']
})
export class TrackingsComponent implements OnInit {
  trackId:number =0;
  constructor(
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.trackId = this.route.snapshot.params.trackId ;
  }

}
