import { ComponentFixture, discardPeriodicTasks, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { of } from 'rxjs';
import { PizzaService } from '../services/pizza.service';

import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let pizzaServiceMock: any;

  pizzaServiceMock = jasmine.createSpyObj(['getPizzaConfig', 'generatePizza']);

  pizzaServiceMock.getPizzaConfig.and.returnValue(of({
    pizzaCookingIntervalInMS: 10000,
    pizzasToGenerator: 50
  }));

  pizzaServiceMock.generatePizza.and.returnValue(of({
    base: 'Deep Pan',
    topping: 'Pepperoni'
  }));

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HomeComponent],
      providers: [{ provide: PizzaService, useValue: pizzaServiceMock }]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    fixture.detectChanges();
    expect(component).toBeTruthy();
  });

  it('should generate 50 pizzas', fakeAsync(() => {
    fixture.detectChanges();
    expect(pizzaServiceMock.getPizzaConfig).toHaveBeenCalled();

    for (let i = 0; i < 50; i++) {
      expect(pizzaServiceMock.generatePizza).toHaveBeenCalled();
      tick(10000);
    }

    discardPeriodicTasks();
  }));
});
