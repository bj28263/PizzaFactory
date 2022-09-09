import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pizza } from '../models/pizza';
import { PizzaConfig } from '../models/pizza-config';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  constructor(private readonly http: HttpClient) { }

  getPizzaConfig() {
    return this.http.get<PizzaConfig>(`/api/pizza/config`);
  }

  generatePizza() {
    return this.http.post<Pizza>(`/api/pizza`, null);
  }

}
