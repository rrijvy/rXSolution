using DemoLibrary.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static ShoppingCart cart = new ShoppingCart();

        static void Main(string[] args)
        {
            PopulateCartWithDemoData();

            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");

            Console.WriteLine("\n");

            decimal total = cart.GenerateTotal((subTotal) => Console.WriteLine($"The subtotal is {subTotal:C2}"),
                (List<Product> items, decimal subTotal) =>
                {
                    if (subTotal > 100)
                    {
                        return subTotal * 0.80M;
                    }
                    else if (subTotal > 50)
                    {
                        return subTotal * 0.85M;
                    }
                    else if (subTotal > 10)
                    {
                        return subTotal * 0.90M;
                    }
                    else
                    {
                        return subTotal;
                    }
                },
                (message) => Console.WriteLine(message));

            Console.WriteLine($"The total for the cart is {total:C2}");

            Console.WriteLine();

            Console.WriteLine($"Please press any key to exit.");

            Console.ReadKey();
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal:C2}");
        }

        private static decimal CalculateLeveledDiscount(List<Product> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.90M;
            }
            else
            {
                return subTotal;
            }
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
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
