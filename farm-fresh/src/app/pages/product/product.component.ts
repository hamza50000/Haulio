import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IProduct } from 'src/app/interfaces/iproduct';
import { ProductService } from 'src/app/services/product.service';
import { ProductDetailComponent } from '../product-detail/product-detail.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  products: IProduct[] = [];
  total: number = 0;
  page: number = 1;
  pageSize: number = 6;
  nextButton: boolean = false;
  prevButton: boolean = true;

  constructor(private service: ProductService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.getProducts();
  }
  next() {
    this.page = this.page + 1;
    this.getProducts();
  }
  previous() {
    if (this.page >= 1) {
      this.page = this.page - 1;
    }
    this.getProducts();
  }

  private getProducts() {
    this.service.getProducts(this.page, this.pageSize).subscribe((data) => {
      this.products = data.item2;
      this.total = data.item1;
      if (this.page * this.pageSize >= this.total) {
        this.nextButton = true;
      } else {
        this.nextButton = false;
      }
      this.prevButton = this.page == 1 ? true : false;
    });
  }

  openDialog(productId: number, name: string, imagePath: string, id: number) {
    this.dialog.open(ProductDetailComponent, {
      data: {
        id: id,
        name: name,
        imagePath: imagePath,
        productId: productId,
      },
      height: '600px',
      width: '1500px',
    });
  }
}
