namespace PizzaFactory.App.Repositories
{
    public class PizzaToppingRepository : IPizzaToppingRepository
    {
        public IEnumerable<string> PizzaToppings;

        public PizzaToppingRepository()
        {
            PizzaToppings = new List<string>()
            {
                "Ham and Mushroom",
                "Pepperoni",
                "Vegetable"
            };
        }

        public string GetRandomTopping()
        {
            return PizzaToppings.ElementAt(Random.Shared.Next(PizzaToppings.Count()));
        }
    }
}
