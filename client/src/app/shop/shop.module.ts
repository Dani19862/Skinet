import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop/shop.component';
import { ProductItemComponent } from './shop/product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent

  ],

  imports: [
    CommonModule,
    SharedModule
  ]
  ,exports: [
    ShopComponent
  ]
})
export class ShopModule { }