using ProductCatalog.Data.DB;
using ProductCatalog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.UI.Menu.ProductMenu
{
    public class ProductMainMenu
    {
        public static Products ProductDB;
        public ProductMainMenu()
        {
            ProductDB = new Products();
        }
        internal void ShowMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"\n\tMain Menu -> Product Menu\n");
                Console.WriteLine("a. Add a Product");
                Console.WriteLine("b. List all Products");
                Console.WriteLine("c. Delete a Product");
                Console.WriteLine("d. Search a Product");
                Console.WriteLine("e. Back\n");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        AddProductMenu.ShowAddProductMenu();
                        break;
                    case "b":
                        DisplayProducts.ShowDisplayProducts();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "c":
                        DeleteProductMenu.ShowDeleteProductMenu();
                        break;
                    case "d":
                        SearchProductMenu.ShowSearchProductMenu();
                        break;
                    case "e":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!!");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}