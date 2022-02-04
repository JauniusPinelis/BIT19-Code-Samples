import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ShopListComponent } from './components/shop-list/shop-list.component';
import { CreateShopComponent } from './components/create-shop/create-shop.component';

@NgModule({
  declarations: [
    AppComponent,
    ShopListComponent,
    CreateShopComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
