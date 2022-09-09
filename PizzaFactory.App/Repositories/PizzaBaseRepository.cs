using PizzaFactory.App.Models;

namespace PizzaFactory.App.Repositories
{
    public class PizzaBaseRepository : IPizzaBaseRepository
    {
        public IEnumerable<PizzaBase> PizzaBases;

        public PizzaBaseRepository()
        {
            PizzaBases = new List<PizzaBase>()
            {
                new PizzaBase() { Name = "Thin and Crispy", Multiplier = 1 },
                new PizzaBase() { Name = "Stuffed Crust", Multiplier = 1.5M },
                new PizzaBase() { Name = "Deep Pan", Multiplier = 2 }
            };
        }

        public PizzaBase GetRandomBase()
        {
            return PizzaBases.ElementAt(Random.Shared.Next(PizzaBases.Count()));
        }
    }
}
