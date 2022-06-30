import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IProductDetail } from 'src/app/interfaces/iproduct-detail';
import { ProductDetailService } from 'src/app/services/product-detail.service';

export interface DialogData {
  id: number;
  name: string;
  imagePath: string;
  productId: number;
}

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
})
export class ProductDetailComponent implements OnInit {
  productDetail!: IProductDetail;
  productName: string = '';
  imagePath: string = '';
  qty: string = '1';
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private service: ProductDetailService
  ) {}

  ngOnInit(): void {
    this.productName = this.data.name;
    this.imagePath = this.data.imagePath;
    this.service.getProductDetailById(this.data.id).subscribe((res) => {
      this.productDetail = res;
    });
  }
  addToCart() {
    this.data.productId;
  }
}
