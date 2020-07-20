import {SelectionModel} from '@angular/cdk/collections';
import {Component,OnInit} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {NotificationModel} from '../../models/notification.model';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {
 
  notifications:NotificationModel[]=[
    {NotificationId:1,Description:"Daily Standup Meeting",Days:2,NotificationStatus:{ NotificationStatusId:1,Description:"Approved"}},
    {NotificationId:1,Description:"Group Town Hall Meet-up with showcase",Days:2,NotificationStatus:{ NotificationStatusId:2,Description:"In Progress"}},
    {NotificationId:1,Description:"Next sprint planning and estimations",Days:2,NotificationStatus:{ NotificationStatusId:3,Description:"Success"}},
    {NotificationId:1,Description:"Sprint delivery and project deployment",Days:2,NotificationStatus:{ NotificationStatusId:4,Description:"Rejected"}},
    {NotificationId:1,Description:"Data analytics research showcase",Days:2,NotificationStatus:{ NotificationStatusId:2,Description:"In Progress"}},
  ];

  displayedColumns: string[] = ['select','Description', 'Status'];
  dataSource = new MatTableDataSource<NotificationModel>(this.notifications);
  selection = new SelectionModel<NotificationModel>(true, []);

  constructor() { }

  ngOnInit(): void {
  }

}
