using Microsoft.Extensions.Options;
using Moq;
using PizzaFactory.App;
using PizzaFactory.App.Models;
using PizzaFactory.App.Repositories;
using PizzaFactory.App.Settings;

namespace PizzaFactory.UnitTests
{
    public class PizzaGeneratorTests
    {
        private readonly PizzaGenerator SUT;
        private PizzaConfig PizzaConfig;
        private Mock<IPizzaBaseRepository> PizzaBaseRepositoryMock;
        private Mock<IPizzaToppingRepository> PizzaToppingRepositoryMock;

        public PizzaGeneratorTests()
        {
            PizzaConfig = new PizzaConfig();
            var pizzaSettings = Options.Create(PizzaConfig);
            PizzaBaseRepositoryMock = new Mock<IPizzaBaseRepository>();
            PizzaToppingRepositoryMock = new Mock<IPizzaToppingRepository>();

            SUT = new PizzaGenerator(pizzaSettings, PizzaBaseRepositoryMock.Object, PizzaToppingRepositoryMock.Object);
        }

        [InlineData(3000, 100, "Deep Pan", 2, "Pepperoni", 6900)]
        [InlineData(1000, 100, "Stuffed Crust", 1.5, "Ham and Mushroom", 3100)]
        [InlineData(1000, 100, "Thin and Crispy", 1, "Vegetable", 1900)]
        [Theory]
        public void CalculatePizzaCookingTime(int pizzaBaseCookingTimeInMS, int pizzaToppingCookingTimeInMS, string baseName, decimal baseMultiplier, string toppingName, int duration)
        {
            //Arrange
            PizzaConfig.PizzaBaseCookingTimeInMS = pizzaBaseCookingTimeInMS;
            PizzaConfig.PizzaToppingCookingTimeInMS = pizzaToppingCookingTimeInMS;

            PizzaBaseRepositoryMock.Setup(x => x.GetRandomBase()).Returns(() => new PizzaBase() { Name = baseName, Multiplier = baseMultiplier });
            PizzaToppingRepositoryMock.Setup(x => x.GetRandomTopping()).Returns(() => toppingName);

            //Act
            var pizza = SUT.GeneratePizza();

            //Assert
            Assert.Equal(duration, pizza.CookingTime);
        }
    }
}