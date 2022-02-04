import { Component, OnInit } from '@angular/core';
import { ShopsService } from 'src/app/services/shops.service';
import Shop from 'src/app/models/shop.model';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.scss']
})
export class ShopListComponent implements OnInit {

  public text: string = 'Super Shop List';

  public shops: Shop[] = [
    {
      id: 1,
      name: 'Maxima'
    },
    {
      id: 2,
      name: 'Norfa'
    },
    {
      id: 3,
      name: 'Lidl'
    }
  ]

  constructor(private shopService: ShopsService) {

  }

  ngOnInit(): void {
    this.shopService.getAllShops().subscribe((shops) => {
      this.shops = shops;
    });
  }

}
