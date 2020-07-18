import { OrderModel } from "./order.model";
import {TrackingStatusModel} from "./tracking-status.model";
import {TrackingProductModel} from "./tracking-product.model";

export class TrackingModel {
    TrackingId: number;
    OrderId: number;
    EstimatedDeliveryTime: string;
    TrackingStatusId: number;
    Order: OrderModel;
    TrackingStatus: TrackingStatusModel;
    TrackingProducts: TrackingProductModel[];
}