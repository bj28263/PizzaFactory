namespace PizzaFactory.App.Settings
{
    public class PizzaConfig
    {
        public int PizzasToGenerator { get; set; }

        public int PizzaBaseCookingTimeInMS { get; set; }

        public int PizzaToppingCookingTimeInMS { get; set; }

        public int PizzaCookingIntervalInMS { get; set; }
    }
}
