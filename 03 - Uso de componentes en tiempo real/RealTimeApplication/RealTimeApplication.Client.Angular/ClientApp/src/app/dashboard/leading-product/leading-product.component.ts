import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../services/data/products.service';
import { ProductModel } from 'src/app/models/product.model';

@Component({
  selector: 'app-leading-product',
  templateUrl: './leading-product.component.html',
  styleUrls: ['./leading-product.component.scss']
})
export class LeadingProductComponent implements OnInit {

  displayedColumns: string[] = ['FileImage', 'Description', 'Price'];
  products:ProductModel[] = [];

  constructor(
   private productsService: ProductsService
) { }

  ngOnInit(): void {
    this.list();
  }

  list() {
    this.productsService.list().subscribe(products => {
      this.products = products;
    });
  }
}
