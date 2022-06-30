import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct } from '../interfaces/iproduct';
import { ITuple } from '../interfaces/iTuple';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly baseUrl = `https://localhost:44361/api/Products`;

  public constructor(private http: HttpClient) {}

  public getProducts(
    page: number,
    pageSize: number
  ): Observable<ITuple<number, IProduct[]>> {
    return this.http.get<ITuple<number, IProduct[]>>(
      `${this.baseUrl}?page=${page}&pageSize=${pageSize}`
    );
  }
}
