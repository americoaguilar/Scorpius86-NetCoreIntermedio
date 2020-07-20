import {NotificationStatusModel} from './notification-status.model';

export class NotificationModel {
  NotificationId:number;
  Description:string;
  Days:number;
  NotificationStatus: NotificationStatusModel;
}
