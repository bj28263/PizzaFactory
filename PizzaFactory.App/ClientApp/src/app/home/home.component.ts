import { Component, OnInit } from '@angular/core';
import { switchMap, takeWhile, timer } from 'rxjs';
import { Pizza } from '../models/pizza';
import { PizzaService } from '../services/pizza.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private readonly pizzaService: PizzaService) { }

  pizzas: Pizza[] = [];

  ngOnInit(): void {
    this.pizzaService.getPizzaConfig().subscribe(config => {
      timer(0, config.pizzaCookingIntervalInMS)
        //Complete the observable when the interval has run for the amount of pizzas needing to be generated.
        .pipe(takeWhile(count => count < config.pizzasToGenerator), switchMap(() => this.pizzaService.generatePizza()))
        .subscribe(pizza => {
          this.pizzas.push(pizza);
        }, () => { }, () => {
          window.close();
        });
    });
  }

}
