# How does it work
When the site loads the home component makes a call to the API to get the config.
These settings are in the appsettings.json file. The config is read from the json
file and added to the dependency injection using the options pattern.

After it gets the settings it starts an interval observable using the setting
pizzaCookingIntervalInMS. The interval runs a fixed number of times based on the
setting pizzasToGenerator.

Each time it runs it does a post to /api/pizza. The GeneratePizza action on the
controller PizzaController uses the PizzaGenerator class to create a random pizza.

The PizzaGenerator injects repositories for the base and topping. It uses the
repositories to get a random base and topping. It calculates the cooking time using
the setting PizzaBaseCookingTimeInMS * the pizza base multiplier defined in the
repository + the setting PizzaToppingCookingTimeInMS * the length of the pizza
topping name. It then sleeps for the cooking time.

# Design decisions
I decided to not put the pizza generator logic in the controller to keep the routing
logic in the controller separate from the pizza logic. I created repositories for
the pizza bases and toppings to allow mocking them in unit tests to test base and
topping combinations and assert the cooking times are correct.