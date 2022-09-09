using Microsoft.Extensions.Options;
using PizzaFactory.App.Models;
using PizzaFactory.App.Repositories;
using PizzaFactory.App.Settings;

namespace PizzaFactory.App
{
    public class PizzaGenerator
    {
        private readonly PizzaConfig PizzaConfig;
        private readonly IPizzaBaseRepository PizzaBaseRepository;
        private readonly IPizzaToppingRepository PizzaToppingRepository;

        public PizzaGenerator(
            IOptions<PizzaConfig> pizzaConfig,
            IPizzaBaseRepository pizzaBaseRepository,
            IPizzaToppingRepository pizzaToppingRepository)
        {
            PizzaConfig = pizzaConfig.Value;
            PizzaBaseRepository = pizzaBaseRepository;
            PizzaToppingRepository = pizzaToppingRepository;
        }

        /// <summary>
        /// Generate a random pizza, calculate the cooking time based on the base time multiplied by
        /// the multiplier plus the topping time multiplied by the number of characters in the topping.
        /// </summary>
        /// <returns>The pizza</returns>
        public Pizza GeneratePizza()
        {
            var pizzaBase = PizzaBaseRepository.GetRandomBase();
            var pizzaTopping = PizzaToppingRepository.GetRandomTopping();
            var pizza = new Pizza
            {
                Base = pizzaBase.Name,
                Topping = pizzaTopping,
                CookingTime = 0
            };

            pizza.CookingTime += PizzaConfig.PizzaBaseCookingTimeInMS * pizzaBase.Multiplier;
            pizza.CookingTime += PizzaConfig.PizzaToppingCookingTimeInMS * pizzaTopping.Length;
            Thread.Sleep(decimal.ToInt32(pizza.CookingTime));

            return pizza;
        }
    }
}
