import { Component, OnInit } from '@angular/core';
import {TrendingItemModel} from '../../models/trending-item.model';

@Component({
  selector: 'app-trending-item',
  templateUrl: './trending-item.component.html',
  styleUrls: ['./trending-item.component.scss']
})
export class TrendingItemComponent implements OnInit {

  displayedColumns: string[] = ['FileImageIcon', 'Description', 'Percentage'];
  trendingItems:TrendingItemModel[]=[
    {Description:'Top Authors',Detail:'Successful Fellas',Percentage:65,FileImageIcon:'006-plurk.svg'},
    {Description:'Popular Authors',Detail:'Most Successful',Percentage:83,FileImageIcon:'015-telegram.svg'},
    {Description:'New Users',Detail:'Awesome Users',Percentage:47,FileImageIcon:'003-puzzle.svg'},
    {Description:'Active Customers',Detail:'Best Customers',Percentage:71,FileImageIcon:'005-bebo.svg'},
    {Description:'Bestseller Theme',Detail:'Amazing Templates',Percentage:50,FileImageIcon:'014-kickstarter.svg'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
