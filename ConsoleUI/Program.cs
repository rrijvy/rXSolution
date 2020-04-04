using DemoLibrary.Models;
using System;

namespace ConsoleUI
{
    class Program
    {
        static ShoppingCart cart = new ShoppingCart();

        static void Main(string[] args)
        {
            PopulateCartWithDemoData();

            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert):C2}");

            Console.WriteLine();

            Console.WriteLine($"Please press any key to exit.");

            Console.ReadKey();
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal:C2}");
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new Product { Name = "Cereal", Price = 3.63M });
            cart.Items.Add(new Product { Name = "Milk", Price = 2.95M });
            cart.Items.Add(new Product { Name = "Strawberries", Price = 7.51M });
            cart.Items.Add(new Product { Name = "Blueberries", Price = 8.84M });
        }
    }
}
