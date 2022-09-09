using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PizzaFactory.App.Models;
using PizzaFactory.App.Settings;

namespace PizzaFactory.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaGenerator PizzaGenerator;
        private readonly PizzaConfig PizzaConfig;

        public PizzaController(PizzaGenerator pizzaGenerator, IOptions<PizzaConfig> pizzaConfig)
        {
            PizzaGenerator = pizzaGenerator;
            PizzaConfig = pizzaConfig.Value;
        }

        /// <summary>
        /// Get config like the number of pizzas to generate and the interval.
        /// </summary>
        /// <returns>The config for the factory.</returns>
        [HttpGet("config")]
        public PizzaConfig GetConfig()
        {
            return PizzaConfig;
        }

        /// <summary>
        /// Generates a pizza with a random base and a random topping.
        /// </summary>
        /// <returns>The pizza with the name of the base, topping and the cooking time.</returns>
        [HttpPost]
        public Pizza GeneratePizza()
        {
            return PizzaGenerator.GeneratePizza();
        }
    }
}
