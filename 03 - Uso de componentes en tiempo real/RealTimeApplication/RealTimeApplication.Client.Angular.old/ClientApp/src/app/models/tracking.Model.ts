import { OrderModel } from "./order.model";
import {TrackingStatusModel} from "./tracking-status.model";
import {TrackingProductModel} from "./tracking-product.model";

export class TrackingModel {
    TrackingId: number;
    OrderId: number;
    EstimatedDeliveryTime: Date;
    TrackingStatusId: number;
    Order: OrderModel;
    TrackingStatus: TrackingStatusModel;
    TrackingProducts: TrackingProductModel[];
    
    constructor(){
        this.TrackingId=0;
        this.OrderId = 0;
        this.EstimatedDeliveryTime =  new Date();
        this.Order = new OrderModel();
        this.TrackingStatus = new TrackingStatusModel();
        this.TrackingProducts = new Array<TrackingProductModel>();
    }
}