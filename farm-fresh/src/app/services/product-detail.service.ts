import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProductDetail } from '../interfaces/iproduct-detail';

@Injectable({
  providedIn: 'root',
})
export class ProductDetailService {
  private readonly baseUrl = `https://localhost:44361/api/ProductDetails`;

  public constructor(private http: HttpClient) {}

  public getProductDetailById(id: number): Observable<IProductDetail> {
    return this.http.get<IProductDetail>(`${this.baseUrl}/${id}`);
  }
}
