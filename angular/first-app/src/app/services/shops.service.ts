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
    return this.httpClient.get<Shop[]>("https://localhost:44338/todo");
  }

  public createShop(createShop: CreateShop): Observable<any> {
    return this.httpClient.post("https://localhost:44338/todo", createShop)
  }
}
