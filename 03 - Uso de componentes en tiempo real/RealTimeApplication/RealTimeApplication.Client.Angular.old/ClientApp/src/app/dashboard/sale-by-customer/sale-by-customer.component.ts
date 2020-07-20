import { Component, OnInit } from '@angular/core';
import { ClientsService } from '../../services/data/clients.service';
import { ClientModel } from 'src/app/models/client.model';

@Component({
  selector: 'app-sale-by-customer',
  templateUrl: './sale-by-customer.component.html',
  styleUrls: ['./sale-by-customer.component.scss']
})
export class SaleByCustomerComponent implements OnInit {

  displayedColumns: string[] = ['FileImageIcon', 'Name', 'Paid', 'AveragePercentage','Action'];
  clients:ClientModel[] = [];

constructor(
  private clientsService: ClientsService
) { }

  ngOnInit(): void {
    this.list();
  }

  list() {
    this.clientsService.list().subscribe(clients => {
      this.clients = clients;
    });
  }

}
