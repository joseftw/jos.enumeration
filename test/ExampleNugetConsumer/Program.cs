using ExampleNugetConsumer;
using System;

var pizzas = Pizza.GetAll();

Console.WriteLine("We have the following pizzas: ");
foreach(var pizza in pizzas)
{
    Console.WriteLine(pizza.Description);
}
