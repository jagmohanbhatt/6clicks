using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TaxManager.Application;
using TaxManager.Domain;
using TaxManager.Domain.Entities;
using TaxManager.Domain.Factory;
using TaxManager.Infrastructure;

namespace TaxManager
{
    public class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddTransient<ITaxRateProvider, TaxRateProvider>()
                .AddTransient<BasicTaxFactory>()
                .AddTransient<ImportTaxFactory>()
                .AddTransient<TaxDetail>()
                .AddTransient<ShoppingResult>()
                .AddTransient<CartItem>()
                .AddTransient<Cart>()
                .BuildServiceProvider();

            //Create Item in run time for this demo

            Item[] items_1 = new Item[]
            {
               new Item(ItemType.Book, "Test Book1", 1, 12.49m, false),
               new Item(ItemType.Music, "Music CD", 1, 14.99m, false),
               new Item(ItemType.Food, "Chocolate", 1, 0.85m, false)
            };

            Item[] items_2 = new Item[] 
            {
               new Item(ItemType.ImportedChocolate, "Test Book1", 1, 10.00m, true),
               new Item(ItemType.Perfume, "Music CD", 1, 47.50m, true)
            };

            Cart cart1 = serviceProvider.GetService<Cart>();
            Console.WriteLine("-------------------Input 1--------------------");
            cart1.AddItemToCart(items_1);

            ShoppingResult result_1 = cart1.Buy();
            result_1.ItemsBilled.ForEach(delegate (Item item)
            {
                Console.WriteLine("");
                Console.Write($"{item.Qty} {item.Name} at ${item.Price}");
                if(item.IsExempted())
                    Console.Write($"(Exempted from tax)\n");
            });

            Console.WriteLine("-------------------Ouput 1--------------------");

            Console.WriteLine($"Total Sales Tax: {result_1.TotalSalesTax}");
            Console.WriteLine($"Import Tax: {result_1.TotalImportTax}");
            Console.WriteLine($"Total: {result_1.Total}");

            Console.WriteLine("-------------------Input 2--------------------");


            Cart cart2 = serviceProvider.GetService<Cart>();
            cart2.AddItemToCart(items_2);
            ShoppingResult result_2 = cart2.Buy();
            foreach (var item in result_2.ItemsBilled)
            {
                Console.WriteLine($"{item.Qty} {item.Name} at ${item.Price}");
            }

            Console.WriteLine("-------------------Ouput 2--------------------");

            Console.WriteLine($"Total Sales Tax: {result_2.TotalSalesTax}");
            Console.WriteLine($"Import Tax: {result_2.TotalImportTax}");
            Console.WriteLine($"Total: {result_2.Total}");

            Console.ReadLine();
        }
    }
}
