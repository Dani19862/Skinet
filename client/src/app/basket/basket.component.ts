import { Component } from '@angular/core';
import { BasketService } from './basket.service';
import { BasketItem } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent {

  constructor(public basketSerice: BasketService){

  }

  incrementQuantity(item: BasketItem){
    this.basketSerice.addItemToBasket(item);
  }

  removeItem(id: number, quntity: number){
    this.basketSerice.removeItemFromBasket(id,quntity);
  }

}
