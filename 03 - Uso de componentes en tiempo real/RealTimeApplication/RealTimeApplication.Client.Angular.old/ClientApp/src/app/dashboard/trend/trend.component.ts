import { Component, OnInit } from '@angular/core';
import {TrendModel} from '../../models/trend.model';

@Component({
  selector: 'app-trend',
  templateUrl: './trend.component.html',
  styleUrls: ['./trend.component.scss']
})
export class TrendComponent implements OnInit {
  trends:TrendModel[]=[
    {FileImageIcon:'006-plurk.svg',Description:'Top Authors',Detail:'A brief write up about the top Authors that fits within this section',Days:5},
    {FileImageIcon:'015-telegram.svg',Description:'Popular Authors',Detail:'A brief write up about the Popular Authors that fits within this section',Days:5},
    {FileImageIcon:'014-kickstarter.svg',Description:'New Users',Detail:'A brief write up about the New Users that fits within this section',Days:5},
  ];
  
  constructor() { }

  ngOnInit(): void {
  }

}
