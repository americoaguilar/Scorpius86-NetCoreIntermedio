import { ClientModel } from "./client.model";
import { TrackingModel} from "./tracking.model";

export class OrderModel {
    OrderId: number;
    ClientId: number;
    Description: string;
    Client: ClientModel;
    Trackings: TrackingModel[];
    
    constructor(){
        this.Client=new ClientModel();
    }
}