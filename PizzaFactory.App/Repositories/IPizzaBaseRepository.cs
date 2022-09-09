using PizzaFactory.App.Models;

namespace PizzaFactory.App.Repositories
{
    public interface IPizzaBaseRepository
    {
        PizzaBase GetRandomBase();
    }
}
