import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { CreateShopComponent } from './components/create-shop/create-shop.component';
import { ShopListComponent } from './components/shop-list/shop-list.component';

const routes: Routes = [
  { path: 'create-shop', component: CreateShopComponent},
  { path: 'shops', component: ShopListComponent},
  { path: '',   redirectTo: '/shops', pathMatch: 'full' }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
