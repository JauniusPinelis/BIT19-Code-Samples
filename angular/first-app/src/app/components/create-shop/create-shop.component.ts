import { Component, OnInit } from '@angular/core';
import CreateShop from 'src/app/models/create-shop.model';
import { ShopsService } from 'src/app/services/shops.service';

@Component({
  selector: 'app-create-shop',
  templateUrl: './create-shop.component.html',
  styleUrls: ['./create-shop.component.scss']
})
export class CreateShopComponent implements OnInit {

  public title: string = '';

  constructor(private shopService: ShopsService) { }

  ngOnInit(): void {
  }

  public submitNewShop(): void {
    let createShop: CreateShop = {
      title: this.title
    };

    this.shopService.createShop(createShop).subscribe(() => {
      console.log("Shop was created");
      // Update the list as well
    })
  }

}
