import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import CreateShop from '../models/create-shop.model';
import Shop from '../models/shop.model';

@Injectable({
  providedIn: 'root'
})
export class ShopsService {

  constructor(private httpClient: HttpClient) {
   }

  public getAllShops(): Observable<Shop[]> {
    return this.httpClient.get<Shop[]>("https://jsonplaceholder.typicode.com/posts");
  }

  public createShop(createShop: CreateShop): Observable<any> {
    return this.httpClient.post("https://jsonplaceholder.typicode.com/posts", createShop)
  }
}
